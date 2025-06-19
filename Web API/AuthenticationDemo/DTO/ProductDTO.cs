namespace AuthenticationDemo.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int SellingPrice { get; set; }
    }
}
