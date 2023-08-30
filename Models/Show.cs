namespace WatchlistReact.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }

        public ICollection<WatchlistShow> Watchlists { get; set; }

        public ICollection<ShowStatus> ShowStatuses { get; set; }
    }
}
