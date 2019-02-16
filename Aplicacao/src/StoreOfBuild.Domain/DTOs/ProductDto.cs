namespace StoreOfBuild.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }
    }
}