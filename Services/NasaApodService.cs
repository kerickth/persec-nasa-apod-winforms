using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using NasaApod_App.Models;
using System.Net;
using NasaApod_App.Exceptions;
using Microsoft.Extensions.Configuration;

namespace NasaApod_App.Services
{
    public class NasaApodService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public NasaApodService(HttpClient http, string apiKey)
        {
            _http = http;
            _apiKey = apiKey;
        }

        public async Task<List<ApodItem>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            string url =
                $"?api_key={_apiKey}" +
                $"&start_date={start:yyyy-MM-dd}" +
                $"&end_date={end:yyyy-MM-dd}";

            using var response = await _http.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new ApiKeyInvalidException();

            if (!response.IsSuccessStatusCode)
                throw new Exception("NASA API not available");

            var json = await response.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<List<ApodItem>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (items == null)
                throw new Exception("No data returned from NASA API");

            return items;
        }
    }
}
