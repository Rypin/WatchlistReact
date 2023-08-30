namespace WatchlistReact.Models
{
    public class WatchlistComments
    {
        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }

        public int ShowId { get; set; }
        public Show Show { get; set; }

        public string Comment { get; set; }
    }
}
