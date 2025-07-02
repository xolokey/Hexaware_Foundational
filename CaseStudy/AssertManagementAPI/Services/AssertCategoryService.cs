using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.AssertCategory;
using AssertManagementAPI.Model.AssetManagementAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace AssertManagementAPI.Services
{
    public class AssertCategoryService:IAssertCategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AssertCategoryService(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        //To Get All Assert Category
        public async Task<List<AssertCategoryDTO>> GetAllCategory()
        {
            try
            {
                var category = await _context.AssetCategories.Where(c=> c.IsActive)
                    .Select(c=> new AssertCategoryDTO
                    {
                       CategoryId= c.CategoryId,
                       CategoryName= c.CategoryName,
                       Description= c.Description,
                       IsActive= c.IsActive,

                    })
                    .ToListAsync();
                return category;

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Info!!{ex.Message}"); }
        }
        //To Get Category By ID
        public async Task<AssertCategoryDTO> GetCategoryById(int Id)
        {
            try
            {
                var category = await _context.AssetCategories.Where(c=> c.CategoryId == Id && c.IsActive).FirstOrDefaultAsync();
                if (category != null)
                {
                    return _mapper.Map<AssertCategoryDTO>(category);
                }
                else { return null; }

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Info!!{ex.Message}"); }
        }
        //To Create a New Category
        public async Task<string> CreateCategory(CreateAssertCategoryDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    var category = new AssertCategory
                    {
                        CategoryName = dto.CategoryName,
                        Description = dto.Description,
                        IsActive = true,
                    };
                    await _context.AssetCategories.AddAsync(category);
                    await _context.SaveChangesAsync();
                    return "....Category Added Successfully....";
                }
                else { return "Enter the Required Details!!"; }


            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Info!!{ex.Message}"); }
        }
        //To Update a category
        public async Task<string> UpdateCategory(UpdateAssertCategoryDTO dto,int Id)
        {
            try
            {
                var category = await _context.AssetCategories.Where(c=> c.CategoryId==Id && c.IsActive).FirstOrDefaultAsync();
                if (category != null)
                {
                    category.CategoryName = dto.CategoryName;
                    category.Description = dto.Description;
                    category.IsActive = dto.IsActive;
                    await _context.SaveChangesAsync();
                    return "....Category Updated Successfully....";
                }
                else { return "Enter Valid Details To Update!!"; }
            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Info!!{ex.Message}"); }
        }
        //To SoftDelete a Category
        public async Task<string> DeleteCategory(int Id)
        {
            try
            {
                var category = await _context.AssetCategories.Where(c=> c.CategoryId == Id && c.IsActive).FirstOrDefaultAsync();
                if (category != null) 
                {
                    category.IsActive=false;
                    await _context.SaveChangesAsync();
                    return $"....Category With Name: {category.CategoryName} Deleted....";
                }
                else { return "No Category With ID Found!!"; }

            }
            catch (Exception ex) { throw new Exception($"Error While Fetching Info!!{ex.Message}"); }
        }
    }
}
