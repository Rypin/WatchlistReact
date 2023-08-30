namespace WatchlistReact.Models
{
    public class ShowStatus
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public string Comments { get; set; } //Current thoughts
        public int Progress { get; set; }   //current episode
        public string Status { get; set; } //watching,onhold, dropped, finished
        public string Score { get; set; }// 1-10 with option for custom score name

    }
}
