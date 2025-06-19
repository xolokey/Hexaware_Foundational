namespace AuthenticationDemo.DTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int SellingPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
