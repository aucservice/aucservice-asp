namespace AucService.Model
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int OwnerId { get; set; }
        public int MaxBetCount { get; set; }
    }
}