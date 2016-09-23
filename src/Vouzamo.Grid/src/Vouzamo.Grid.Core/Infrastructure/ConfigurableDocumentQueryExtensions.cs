using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vouzamo.Grid.Core.Infrastructure
{
    /// <summary>
    /// Adds extensions methods to DocumentClient and IQuerable&lt;T&gt;
    /// </summary>
    public static class ConfigurableDocumentQueryExtensions
    {
        /// <summary>
        /// Creates a IOrderedQueryable&lt;T&gt; that handles deserialization using the specified JsonSerializerSettings.
        /// </summary>
        /// <typeparam name="T">The type to query.</typeparam>
        /// <param name="client">The DocumentClient.</param>
        /// <param name="docsLink">The SelfLink of the DocumentCollection to query over.</param>
        /// <param name="settings">The JsonSerialiserSettings used to deserialize the objects returned by the query.</param>
        /// <returns>An IOrderedQueryable&lt;T&gt; to query.</returns>
        public static IOrderedQueryable<T> CreateDocumentQuery<T>(this DocumentClient client, string docsLink, JsonSerializerSettings settings)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (string.IsNullOrWhiteSpace(docsLink))
            {
                throw new ArgumentNullException(nameof(docsLink));
            }

            return new ConfigurableDocumentQuery<T>(client, docsLink, client.CreateDocumentQuery<T>(docsLink), settings ?? new JsonSerializerSettings());
        }

        /// <summary>
        /// Enumerates the IQueryable&lt;T&gt; and deserializes the query using the provided JsonSerializerSettings.
        /// </summary>
        /// <typeparam name="T">The type to query.</typeparam>
        /// <param name="query">The query to enumerate.</param>
        /// <param name="client">The DocumentClient.</param>
        /// <param name="docsLink">The SelfLink of the DocumentCollection to query over.</param>
        /// <param name="settings">The JsonSerialiserSettings used to deserialize the objects returned by the query.</param>
        /// <returns>An IEnumerable&lt;T&gt; containing deserialized objects of type T.</returns>
        public static IEnumerable<T> AsEnumerable<T>(this IQueryable<T> query, DocumentClient client, string docsLink, JsonSerializerSettings settings)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (string.IsNullOrWhiteSpace(docsLink))
            {
                throw new ArgumentNullException(nameof(docsLink));
            }
            if (settings == null)
            {
                settings = new JsonSerializerSettings();
            }
            var type = query.Expression.Type.GetGenericArguments().First();
            var queryInfo = JsonConvert.DeserializeObject<QueryInfo>(query.ToString());

            var x = client.CreateDocumentQuery(docsLink, queryInfo.Query);
            Type itemType = null;
            foreach (var d in x)
            {
                if (itemType == null)
                    itemType = d.GetType();

                if (itemType == typeof(JValue))
                    yield return d;
                else
                {
                    var json = d.ToString();

                    var j = JObject.Parse(json);

                    var jType = j.GetValue("$type");

                    var t = Type.GetType(jType.Value);

                    if (typeof(T).IsAssignableFrom(t))
                    {
                        yield return JsonConvert.DeserializeObject(d.ToString(), t, settings);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentCollectionLink"></param>
        /// <param name="document"></param>
        /// <param name="options"></param>
        /// <param name="disableAutomaticIdGeneration"></param>
        /// <returns></returns>
        public static Task<ResourceResponse<Document>> CreateDocumentAsync(this DocumentClient client, string documentCollectionLink, object document, JsonSerializerSettings settings, RequestOptions options = null, bool disableAutomaticIdGeneration = false)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (string.IsNullOrWhiteSpace(documentCollectionLink))
            {
                throw new ArgumentNullException(nameof(documentCollectionLink));
            }
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }
            if (settings == null)
            {
                settings = new JsonSerializerSettings();
            }

            var newDocument = new Document();
            var serializer = JsonSerializer.Create(settings);
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms, Encoding.UTF8, 4096, true))
                {
                    serializer.Serialize(writer, document);
                }
                ms.Position = 0;
                using (var reader = new StreamReader(ms))
                {
                    var jsonReader = new JsonTextReader(reader);
                    newDocument.LoadFrom(jsonReader);
                }
            }
            return client.CreateDocumentAsync(documentCollectionLink, newDocument, options, disableAutomaticIdGeneration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="documentCollectionLink"></param>
        /// <param name="document"></param>
        /// <param name="settings"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<ResourceResponse<Document>> ReplaceDocumentAsync(this DocumentClient client, string documentCollectionLink, object document, JsonSerializerSettings settings, RequestOptions options = null)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            if (string.IsNullOrWhiteSpace(documentCollectionLink))
            {
                throw new ArgumentNullException(nameof(documentCollectionLink));
            }
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }
            if (settings == null)
            {
                settings = new JsonSerializerSettings();
            }

            var replaceDocument = new Document();
            var serializer = JsonSerializer.Create(settings);
            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms, Encoding.UTF8, 4096, true))
                {
                    serializer.Serialize(writer, document);
                }
                ms.Position = 0;
                using (var reader = new StreamReader(ms))
                {
                    var jsonReader = new JsonTextReader(reader);
                    replaceDocument.LoadFrom(jsonReader);
                }
            }
            replaceDocument.SetPropertyValue("_self", documentCollectionLink);
            return client.ReplaceDocumentAsync(replaceDocument, options);
        }

        private struct QueryInfo
        {
            public string Query { get; set; }
        }
    }
}
