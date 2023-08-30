namespace WatchlistReact.Models
{
    public class Watchlist
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        
        public ICollection<WatchlistShow> Shows { get; set; }

    }
}
