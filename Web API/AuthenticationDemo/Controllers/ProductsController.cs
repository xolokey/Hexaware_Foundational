using AuthenticationDemo.DTO;
using AuthenticationDemo.Models;
using AuthenticationDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IproductRepo _productRepo;
        public ProductsController(IproductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet("AllProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productRepo.GetAllProducts();
                return products == null || !products.Any() ? NotFound("No products found.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetAllProducts: {ex.Message}");
            }
        }

        [HttpGet("productbyid/{id:int}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productRepo.GetProductById(id);
                return product == null ? NotFound($"Product with ID {id} not found.") : Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductById: {ex.Message}");
            }
        }

        [HttpGet("searchbyname")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            try
            {
                var products = _productRepo.GetProductByName(name);
                return products == null || !products.Any() ? NotFound($"No products found with name '{name}'.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductByName: {ex.Message}");
            }
        }

        [HttpGet("searchbyprice")]
        public IActionResult GetProductsByPrice([FromQuery] int price)
        {
            try
            {
                var products = _productRepo.SearchProductsByPrice(price);
                return products == null || !products.Any() ? NotFound($"No products found with price >= {price}.") : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductsByPrice: {ex.Message}");
            }
        }

        [HttpPost("addnewproduct")]
        public IActionResult AddProduct([FromBody] ProductCreationDTO productDTO)
        {
            var result = _productRepo.AddProduct(productDTO);
            return Ok(result);
        }

        [HttpPut("updateproduct/{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateDTO product)
        {
            try
            {
                if (product == null) return BadRequest("Product data is invalid.");
                var result = _productRepo.UpdateProduct(id, product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in UpdateProduct: {ex.Message}");
            }
        }

        [HttpDelete("deleteproduct/{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = _productRepo.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in DeleteProduct: {ex.Message}");
            }
        }

        [HttpGet("category/{category}")]
        public IActionResult GetProductsByCategory(string category)
        {
            try
            {
                var products = _productRepo.GetProductsByCategory(category);
                return products == null || !products.Any()
                    ? NotFound($"No products found in category '{category}'.")
                    : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetProductsByCategory: {ex.Message}");
            }
        }

        [HttpGet("lowstock/{threshold:int}")]
        public IActionResult GetLowStockProducts(int threshold)
        {
            try
            {
                var products = _productRepo.GetLowStockProducts(threshold);
                return products == null || !products.Any()
                    ? NotFound($"No low stock products found below quantity {threshold}.")
                    : Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in GetLowStockProducts: {ex.Message}");
            }
        }

        //[HttpGet("AllProducts")]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        var products = _productRepo.GetAllProducts();
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}

        //[HttpGet("productbyid/{id:int}")]
        //public async Task<IActionResult> GetProductsById(int id)
        //{
        //    try
        //    {
        //        var products = _productRepo.GetProductById(id);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}


        //[HttpGet("searchbyname")]
        //public async Task<IActionResult> GetProductsByName(string name)
        //{
        //    try
        //    {
        //        var products = _productRepo.GetProductByName(name);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}

        //[HttpGet("searchbyprice")]
        //public async Task<IActionResult> GetProductsByPrice(int price)
        //{
        //    try
        //    {
        //        var products = _productRepo.SearchProductsByPrice(price);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}

        //[HttpPost("addnewproduct")]
        //public async Task<IActionResult> CreateProduct(Product product)
        //{
        //    try
        //    {
        //        var products = _productRepo.AddProduct(product);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}

        //[HttpPut("updateproduct/{id:int}")]
        //public async Task<IActionResult> CreateProduct(int id, Product product)
        //{
        //    try
        //    {
        //        var products = _productRepo.UpdateProduct(id, product);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}

        //[HttpDelete("deleteproduct/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var products = _productRepo.DeleteProduct(id);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetAllProducts ${ex.Message}");
        //    }
        //}
    }


}
