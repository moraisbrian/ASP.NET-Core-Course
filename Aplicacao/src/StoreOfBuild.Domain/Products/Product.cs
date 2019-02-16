namespace StoreOfBuild.Domain.Products
{
    public class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StockQuantity { get; private set; }

        public Product(string name, Category category, decimal price, int stock)
        {
            ValidateValues(name, category, price, stock);
            SetProperties(name, category, price, stock);
        }

        public void Update(string name, Category category, decimal price, int stock)
        {
            ValidateValues(name, category, price, stock);
            SetProperties(name, category, price, stock);
        }

        private void SetProperties(string name, Category category, decimal price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stock;
        }

        private static void ValidateValues(string name, Category category, decimal price, int stock)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is requirid");
            DomainException.When(category == null, "Category is null");
            DomainException.When(price < 0, "Price is requirid");
            DomainException.When(stock < 0, "Stock quantity is requirid");
        }
    }
}