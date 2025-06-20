﻿
using AuthenticationDemo.Context;
using AuthenticationDemo.DTO;
using AuthenticationDemo.Models;
using AutoMapper;

namespace AuthenticationDemo.Repository
{
    public class ProductRepo : IproductRepo
    {
        private readonly IMapper _mapper;
        private readonly ProductContext _context;
        public ProductRepo(ProductContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public List<Product> GetAllProducts()
        //{
        //    try
        //    {
        //        var products = _context.Products.ToList();
        //        if (products.Count > 0)
        //            return products;
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($"Exception While GetAllProducts ${ex.Message}");
        //    }
        //}

        //public List<Product> GetProductByName(string name)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(name))
        //        {
        //            var products = _context.Products.Where(p => !string.IsNullOrEmpty(p.Name) &&
        //             p.Name.ToLower().Contains(name.ToLower())).ToList();
        //            return products;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in GetProductByName ${ex.Message}");
        //    }
        //}

        //public List<Product> SearchProductsByPrice(int price)
        //{
        //    try
        //    {

        //        var products = _context.Products.Where(p => p.SellingPrice >= price).ToList();
        //        if (products.Count > 0)
        //            return products;
        //        else
        //            return null;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in SearchProductsByPrice ${ex.Message}");
        //    }
        //}


        //public Product GetProductById(int id)
        //{
        //    try
        //    {

        //        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        //        if (product != null)
        //            return product;
        //        else
        //            return null;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($"Exception in GetProductById ${ex.Message}");
        //    }
        //}

        //public string AddProduct(Product product)
        //{
        //    try
        //    {
        //        if (product != null)
        //        {
        //            _context.Products.Add(product);
        //            _context.SaveChanges();
        //            return " Product Added successfully";
        //        }
        //        else
        //            return "Enter  product details properly";
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public string DeleteProduct(int id)
        //{
        //    try
        //    {
        //        var product = GetProductById(id);
        //        if (product != null)
        //        {
        //            product.IsActive = false;
        //        }
        //        _context.SaveChanges();
        //        return " Product Deleted successfully";

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public string UpdateProduct(int id, Product product)
        //{
        //    try
        //    {
        //        var exisingProduct = GetProductById(id);
        //        if (exisingProduct == null)
        //            return $"Product With the Id {id} Not Found";
        //        exisingProduct.Name = product.Name;
        //        exisingProduct.ManufactureDate = DateTime.Now;
        //        exisingProduct.ManufactureCost = product.ManufactureCost;
        //        exisingProduct.SellingPrice = product.SellingPrice;
        //        exisingProduct.IsActive = product.IsActive;
        //        _context.SaveChanges();

        //        return $"Product with Id {id} is updated successfully";
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception($" Exception in UpdateProduct ${ex.Message}");
        //    }


        //}
        public string AddProduct(ProductCreationDTO productDTO)
        {
            try
            {
                if (productDTO != null)
                {
                    var product = new Product
                    {
                        Name = productDTO.Name,
                        //SKU = productDTO.SKU,
                        //Category = productDTO.Category,
                        ManufactureCost = productDTO.ManufactureCost,
                        SellingPrice = productDTO.SellingPrice,
                        // StockQuantity = productDTO.StockQuantity,
                        // ProductImageUrl = productDTO.ProductImageUrl,
                        ManufactureDate = productDTO.ManufactureDate,
                        //CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return "Product added successfully";
                }
                else
                {
                    return "Enter product details properly";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddProduct: {ex.Message}");
            }
        }
        public string DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();

                //  var newProduct=_mapper.Map<Product>(product);
                if (product != null)
                {
                    product.IsActive = false;
                    //product.UpdatedDate = DateTime.UtcNow;
                    _context.SaveChanges();
                    return "Product marked as inactive (soft deleted)";
                }
                return $"Product with Id {id} not found";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                return _context.Products
                    .Where(p => p.IsActive)
                    .Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ManufactureDate= p.ManufactureDate,
                        SellingPrice = p.SellingPrice

                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllProducts: {ex.Message}");
            }
        }
        public ProductDTO GetProductById(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id && p.IsActive);
                if (product != null)
                    return _mapper.Map<ProductDTO>(product);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductById: {ex.Message}");
            }
        }
        public List<ProductDTO> GetProductByName(string name)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return _context.Products
                        .Where(p => p.Name.ToLower().Contains(name.ToLower()) && p.IsActive)
                         .Select(p => new ProductDTO
                         {
                             Id = p.Id,
                             Name = p.Name,
                             ManufactureDate = p.ManufactureDate,
                             SellingPrice = p.SellingPrice

                         })
                        .ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductByName: {ex.Message}");
            }
        }
        public List<ProductDTO> SearchProductsByPrice(int price)
        {
            try
            {
                return _context.Products
                    .Where(p => p.SellingPrice >= price && p.IsActive)
                     .Select(p => new ProductDTO
                     {
                         Id = p.Id,
                         Name = p.Name,
                         ManufactureDate = p.ManufactureDate,
                         SellingPrice = p.SellingPrice

                     })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in SearchProductsByPrice: {ex.Message}");
            }
        }
        public string UpdateProduct(int id, ProductUpdateDTO productDTO)
        {
            try
            {
                var existingProduct = _context.Products.Where(p => p.Id == id).FirstOrDefault();

                if (existingProduct == null)
                    return $"Product with Id {id} not found";

                existingProduct.Name = productDTO.Name;
                existingProduct.ManufactureDate = productDTO.ManufactureDate;
                existingProduct.SellingPrice = productDTO.SellingPrice;
                _context.SaveChanges();
                return $"Product with Id {id} updated successfully";
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateProduct: {ex.Message}");
            }
        }
        public List<Product> GetProductsByCategory(string category)
        {
            try
            {
                return _context.Products
            .Where(p => p.Category.ToLower() == category.ToLower() && p.IsActive)
            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetProductsByCategory: {ex.Message}");
            }
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            try
            {
                return _context.Products
                    .Where(p => p.StockQuantity <= threshold && p.IsActive)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception in GetLowStockProducts: {ex.Message}");
            }
        }
    }
}
