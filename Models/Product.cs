namespace ProductWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string  ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public required string ProductCategory { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public int Quntity { get; set; }

    }
}
