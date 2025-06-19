namespace AuthenticationDemo.DTO
{
    public class ProductCreationDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ManufactureCost { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int SellingPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
