using AuthenticationDemo.Models;

namespace AuthenticationDemo.Repository
{
    public interface IproductRepo
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public List<Product> GetProductByName(string name);
        public List<Product> SearchProductsByPrice(int price);
        public string AddProduct(Product product);
        public string UpdateProduct(int id, Product product);
        public string DeleteProduct(int id);

    }
}
