namespace WatchlistReact.Models
{
    public class WatchlistShow
    {
        public int Id { get; set; }

        public int ShowId { get; set; }

        public int WatchlistId { get; set; }

        public Watchlist Watchlist { get; set; }

        public Show Show { get; set; }

        public string Comment { get; set; }
    }
}
