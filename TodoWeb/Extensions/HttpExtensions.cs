using Microsoft.AspNetCore.Http;
using System.Text.Json;
using TodoWeb.Helpers;

namespace TodoWeb.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpRequestMessage request, PaginationHeader header)
        {
            var jsonOption = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            request.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOption));
            request.Headers.Add("Access-Control-Expose-Headers", "Pagination");//js
        }
    }
}