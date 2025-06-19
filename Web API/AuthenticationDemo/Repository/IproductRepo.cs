using AuthenticationDemo.Models;
using AuthenticationDemo.DTO;

namespace AuthenticationDemo.Repository
{
    public interface IproductRepo
    {
        public List<ProductDTO> GetAllProducts();
        public ProductDTO GetProductById(int id);
        public List<ProductDTO> GetProductByName(string name);
        public List<ProductDTO> SearchProductsByPrice(int price);
        public string AddProduct(ProductCreationDTO product);
        public string UpdateProduct(int id, ProductUpdateDTO product);
        public string DeleteProduct(int id);
        List<Product> GetProductsByCategory(string category);
        List<Product> GetLowStockProducts(int threshold);

    }
}
