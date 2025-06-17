using WebAppIntegration.Models;

namespace WebAppIntegration.Services
{
    public class ProductServices
    {
        private readonly HttpClient _httpClient;
        public ProductServices(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<Product>> GetProductsAsync() =>
            await _httpClient.GetFromJsonAsync<List<Product>>("api/Products/AllProducts");

        public async Task<Product> GetProductById(int id) =>
            await _httpClient.GetFromJsonAsync<Product>($"api/Products/productbyid/{id}");

        public async Task<Product> GetProductByPrice(int price) =>
            await _httpClient.GetFromJsonAsync<Product>($"api/Products/searchbyprice?price={price}");

        public async Task<List<Product>> SearchProductByName(string name) =>
            await _httpClient.GetFromJsonAsync<List<Product>>($"api/Products/searchbyname?name={name}");

        public async Task CreateProduct(Product product) =>
            await _httpClient.PostAsJsonAsync("api/Products/addnewproduct", product);

        public async Task UpdateProductAsync(int id, Product product) =>
            await _httpClient.PutAsJsonAsync($"api/Products/updateproduct/{id}", product);

        public async Task DeleteProduct(int id) =>
            await _httpClient.DeleteAsync($"api/Products/deleteproduct/{id}");
    }
}
