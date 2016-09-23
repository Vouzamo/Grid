using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Vouzamo.Grid.Core.Infrastructure
{
    public class ConfigurableDocumentQuery<T> : IOrderedQueryable<T>
    {
        private readonly IOrderedQueryable<T> _docQuery;
        private readonly JsonSerializerSettings _settings;
        private readonly DocumentClient _client;
        private readonly string _docsLink;

        public ConfigurableDocumentQuery(DocumentClient client, string docsLink, IOrderedQueryable<T> query, JsonSerializerSettings settings)
        {
            _client = client;
            _docsLink = docsLink;
            _docQuery = query;
            _settings = settings;
            Provider = new ConfigurableDocumentQueryProvider<T>(query.Provider, client, docsLink, settings);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _docQuery.AsEnumerable(_client, _docsLink, _settings).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => _docQuery.ElementType;

        public System.Linq.Expressions.Expression Expression => _docQuery.Expression;

        public IQueryProvider Provider { get; }
    }
}
