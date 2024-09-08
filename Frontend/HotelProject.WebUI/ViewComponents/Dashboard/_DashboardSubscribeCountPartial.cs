using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-api2.p.rapidapi.com/v1/info?username_or_id_or_url=yclgamer"),
                Headers =
    {
        { "x-rapidapi-key", "5a11e26b85mshf15dcf40a6ced36p113028jsnc3b189f1d2e4" },
        { "x-rapidapi-host", "instagram-scraper-api2.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.instagramfollowers = resultInstagramFollowersDto.data.follower_count;
                ViewBag.instagramfollowing = resultInstagramFollowersDto.data.following_count;
            }
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://x-com2.p.rapidapi.com/UserByScreenName/?username=yclgamer"),
                Headers =
    {
        { "x-rapidapi-key", "5a11e26b85mshf15dcf40a6ced36p113028jsnc3b189f1d2e4" },
        { "x-rapidapi-host", "x-com2.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultXFollowersDto resultXFollowersDto = JsonConvert.DeserializeObject<ResultXFollowersDto>(body2);
                ViewBag.xfollowers = resultXFollowersDto.data.user.result.legacy.followers_count;
                ViewBag.xfollowing = resultXFollowersDto.data.user.result.legacy.friends_count;
            }


            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fyucelaybey%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_company_public_url=false"),
                Headers =
    {
        { "x-rapidapi-key", "5a11e26b85mshf15dcf40a6ced36p113028jsnc3b189f1d2e4" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedInFollowersDto resultLinkedInFollowersDto = JsonConvert.DeserializeObject<ResultLinkedInFollowersDto>(body3);
                ViewBag.linkedinfollowers = resultLinkedInFollowersDto.data.follower_count;
                ViewBag.linkedinfollowing = resultLinkedInFollowersDto.data.connection_count;
            }

            return View();
        }
    }
}
