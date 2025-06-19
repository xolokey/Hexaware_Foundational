
namespace AuthenticationDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ManufactureCost {  get; set; }
        public DateTime? ManufactureDate { get; set; }
        public string? Category { get; set; }
        public int StockQuantity {  get; set; }
        public int SellingPrice { get; set; }
        public bool IsActive {  get; set; }=true;

    }
}
