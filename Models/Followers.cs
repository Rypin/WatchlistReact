namespace WatchlistReact.Models
{
    public class Followers
    {
        public int Id { get; set; }

        public string FollowerId { get; set; }
        public ApplicationUser Follower { get; set; }

        //Account being followed
        public string AccountId { get; set; }
        public ApplicationUser FollowedAccount { get; set; }
    }
}
