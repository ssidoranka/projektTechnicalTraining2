namespace WebApplication1.Models
{
    public class CarDetail
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}