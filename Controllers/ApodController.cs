using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasaApod_App.Models;
using NasaApod_App.Services;

namespace NasaApod_App.Controllers
{
    public class ApodController
    {
        private readonly NasaApodService _service;

        public ApodController(HttpClient httpClient, string apiKey)
        {
            _service = new NasaApodService(httpClient, apiKey);
        }

        public async Task<List<ApodItem>> LoadMonthlyAsync(int year, int month)
        {
            var start = new DateTime(year, month, 1);
            var end = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            return await _service.GetByDateRangeAsync(start, end);
        }
    }
}
