using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class ExChangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ExchangeViewModel> exchangeViewModels = new List<ExchangeViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=tr&currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "5a11e26b85mshf15dcf40a6ced36p113028jsnc3b189f1d2e4" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
            return View();
        }
    }
}
