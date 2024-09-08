using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using System.Reflection;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModel = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name={cityName}"),
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
                    bookingApiLocationSearchViewModel = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(bookingApiLocationSearchViewModel.Take(1).ToList());
                }
            }
            else
            {
                List<BookingApiLocationSearchViewModel> bookingApiLocationSearchViewModel = new List<BookingApiLocationSearchViewModel>();
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?locale=tr&name=Ankara"),
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
                    bookingApiLocationSearchViewModel = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(bookingApiLocationSearchViewModel.Take(1).ToList());
                }
            }
            
        }
    }
}
