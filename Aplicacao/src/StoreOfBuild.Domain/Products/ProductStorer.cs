using StoreOfBuild.Domain.DTOs;

namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product> _productRepository;
        private IRepository<Category> _categoryRepository;

        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void Store(ProductDto dto)
        {
            var category = _categoryRepository.GetById(dto.Category);
            DomainException.When(category == null, "Category invalid");

            var product = _productRepository.GetById(dto.Id);
            if(product == null)
            {
                product = new Product(dto.Name, category, dto.Price, dto.StockQuantity);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(dto.Name, category, dto.Price, dto.StockQuantity);
            }
        }
    }
}