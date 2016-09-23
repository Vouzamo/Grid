﻿using System.Linq;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace Vouzamo.Grid.Core.Infrastructure
{
    public class ConfigurableDocumentQueryProvider<T> : IQueryProvider
    {
        private readonly IQueryProvider _inner;
        private readonly DocumentClient _client;
        private readonly string _docsLink;
        private readonly JsonSerializerSettings _settings;

        public ConfigurableDocumentQueryProvider(IQueryProvider inner, DocumentClient client, string docsLink, JsonSerializerSettings settings)
        {
            _inner = inner;
            _client = client;
            _docsLink = docsLink;
            _settings = settings;
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            var innerQuery = _inner.CreateQuery<TElement>(expression);
            return new ConfigurableDocumentQuery<TElement>(_client, _docsLink, (IOrderedQueryable<TElement>)innerQuery, _settings);
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            var innerQuery = _inner.CreateQuery(expression);
            return new ConfigurableDocumentQuery<T>(_client, _docsLink, (IOrderedQueryable<T>)innerQuery, _settings);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            // This will throw an exception because the inner IQueryProvider implementation does not support single return types.
            // e.g. First(), Last() etc are not supported.
            return _inner.Execute<TResult>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            // This will throw an exception because the inner IQueryProvider implementation does not support single return types.
            // e.g. First(), Last() etc are not supported.
            return _inner.Execute(expression);
        }
    }
}
