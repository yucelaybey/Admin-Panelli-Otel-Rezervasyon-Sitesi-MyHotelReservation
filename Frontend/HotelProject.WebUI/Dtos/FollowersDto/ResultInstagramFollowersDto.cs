namespace HotelProject.WebUI.Dtos.FollowersDto
{

    public class ResultInstagramFollowersDto
    {
        public Data data { get; set; }
        public class Data
        {
            public int follower_count { get; set; }
            public int following_count { get; set; }
        }
    }
}
