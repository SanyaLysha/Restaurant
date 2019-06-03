namespace Restaurant.Models
{
    public class OrderViewModel
    {
        public long OrderId { get; set; }
        public long PersonId { get; set; }
        public string PersonFullName { get; set; }
        public int TableId { get; set; }
        public bool Paid { get; set; }
        public float Sum { get; set; }
    }
}