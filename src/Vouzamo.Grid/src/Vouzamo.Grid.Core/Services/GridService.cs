using System;
using System.Collections.Generic;
using Vouzamo.Grid.Common.Models;
using Vouzamo.Grid.Common.Services;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Vouzamo.Grid.Common.Models.Items;
using Vouzamo.Grid.Core.Infrastructure;

namespace Vouzamo.Grid.Core.Services
{
    public class GridService : IGridService
    {
        private DocumentClient Client { get; }
        private Database GridDatabase { get; set; }
        private DocumentCollection ItemLocations { get; set; }
        private DocumentCollection Items { get; set; }

        private JsonSerializerSettings Settings { get; set; }

        public GridService()
        {
            var serviceEndpoint = new Uri("https://grid.documents.azure.com:443/");
            var authKey = "J90OhD46OOhInAHnqGITNKfKsQ5K7SpJhDaTTKr7PHtnjDdkPLXDDppBzU0GHHLGXWLADHkdIAk0ksjEbst8XQ==";

            Client = new DocumentClient(serviceEndpoint, authKey);

            Settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, ContractResolver = new CamelCasePropertyNamesContractResolver() };

            GridDatabase = CreateDatabaseIfNotExists("grid").Result;

            ItemLocations = CreateDocumentCollectionIfNotExists("grid", "locations").Result;
            Items = CreateDocumentCollectionIfNotExists("grid", "items").Result;

            //var item = new WarpItem("warp 1", new Location("default", "default", Point3D.Zero));

            //Client.CreateDocumentAsync(Items.SelfLink, item, Settings).Wait();

            //var itemLocation = new ItemLocation("default", "default", new Point3D(-5, -5, -5), item.Id);

            //Client.CreateDocumentAsync(ItemLocations.SelfLink, itemLocation, Settings).Wait();
        }

        private async Task<Database> CreateDatabaseIfNotExists(string databaseName)
        {
            // Check to verify a database with the id=FamilyDB does not exist
            try
            {
                return await Client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseName));
            }
            catch (DocumentClientException ex)
            {
                // If the database does not exist, create a new database
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return await Client.CreateDatabaseAsync(new Database { Id = databaseName });
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<DocumentCollection> CreateDocumentCollectionIfNotExists(string databaseName, string collectionName)
        {
            try
            {
                return await Client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName));
            }
            catch (DocumentClientException ex)
            {
                // If the document collection does not exist, create a new collection
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    var collectionInfo = new DocumentCollection
                    {
                        Id = collectionName,
                        IndexingPolicy = new IndexingPolicy(new RangeIndex(DataType.String) {Precision = -1})
                    };

                    // Configure collections for maximum query flexibility including string range queries.

                    // Here we create a collection with 400 RU/s.
                    return await Client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(databaseName),
                        collectionInfo,
                        new RequestOptions { OfferThroughput = 400 }
                    );
                }
                else
                {
                    throw;
                }
            }
        }

        public IEnumerable<ItemInstance> GetItems(ILocation location, double range)
        {
            var items = new List<ItemInstance>();

            var json = Client.ExecuteStoredProcedureAsync<string>(UriFactory.CreateStoredProcedureUri("grid", "locations", "rangeQuery"), location.Position.X, location.Position.Y, location.Position.Z, range).Result;

            var itemLocations = JsonConvert.DeserializeObject<List<ItemLocation>>(json, Settings);

            foreach (var itemLocation in itemLocations)
            {
                var itemDocument = Client.ReadDocumentAsync(UriFactory.CreateDocumentUri("grid", "items", itemLocation.ItemId.ToString())).Result;

                var itemJson = itemDocument.Resource.ToString();

                var item = JsonConvert.DeserializeObject<Item>(itemJson, Settings);

                if (item != null)
                {
                    items.Add(new ItemInstance(itemLocation, item));
                }
            }

            return items;
        }
    }
}
