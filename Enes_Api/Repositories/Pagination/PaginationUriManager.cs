﻿using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Net;

namespace Enes_Api.Repositories.Pagination
{

    public class PaginationUriManager : IPaginationUriService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public PaginationUriManager(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public Uri GetPageUri(PaginationQuery paginationQuery)
        {
            var baseUri = httpContextAccessor.GetRequestUri();

            var route = httpContextAccessor.GetRoute();
            var endpoint = new Uri(string.Concat(baseUri, route));
            var queryUri = QueryHelpers.AddQueryString($"{endpoint}", "pageNumber", $"{paginationQuery.PageNumber}");
            queryUri = QueryHelpers.AddQueryString(queryUri, "pageSize", $"{paginationQuery.PageSize}");
            return new Uri(queryUri);
        }
    }
}
