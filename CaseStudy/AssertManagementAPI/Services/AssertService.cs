using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.Assert;
using AssertManagementAPI.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AssertManagementAPI.Services
{
    public class AssertService:IAssertService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AssertService(AppDbContext context,IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }
        //To Get All Assert Details
        public async Task<List<AssertDTO>> AllAssert()
        {
            try
            {
                var asserts = await _context.Asserts.Where(a => a.IsAvailable)
                    .Select(a => new AssertDTO
                    {
                        AssetId = a.AssetId,
                        AssetNo = a.AssetNo,
                        AssetModel = a.AssetModel,
                        ImageURL = a.ImageURL,
                        AssetName = a.AssetName,
                        Status = a.Status,
                        AssetValue = a.AssetValue,
                        AssertQuantity = a.AssertQuantity,
                        ManufacturingDate = a.ManufacturingDate,
                        ExpiryDate = a.ExpiryDate,
                        CategoryId = a.CategoryId,
                        IsAvailable = a.IsAvailable,
                    })
                    .ToListAsync();
                return asserts;

            }
            catch(Exception ex) { throw new Exception($"Exception while fetching Assert Details:{ex.Message}"); }
        }
        //To Get Assert By ID
        public async Task<AssertDTO> AssertById(int id)
        {
            try
            {
                var user = await _context.Asserts.Where(a => a.AssetId == id && a.IsAvailable).FirstOrDefaultAsync();
                if (user!=null)
                {
                    return _mapper.Map<AssertDTO>(user);

                }
                return null;

            }
            catch(Exception ex) { throw new Exception($"Error while fetching Assert Details:{ex.Message}"); }
        }
        //To Get Assert By Name
        public async Task<List<AssertDTO>> AssertByName(string name)
        {
            try
            {
                var asserts = _context.Asserts.Where(a => a.AssetName == name && a.IsAvailable);
                if(asserts.Any())
                {
                    return await _mapper.ProjectTo<AssertDTO>(asserts.AsQueryable()).ToListAsync();
                }
                return null;
                    

            } catch (Exception ex) { throw new Exception($"Error while getting Assert:{ex.Message}"); }
        }
        //To Get Assert By Assert NO
        public async Task<List<AssertDTO>> AssertByAssertNo(string assertNo) 
        {
            try
            {
                var assert = await _context.Asserts.Where(a => a.AssetNo.ToLower().Contains(assertNo.ToLower()) && a.IsAvailable)
                    .Select(a => new AssertDTO
                    {
                        AssetId = a.AssetId,
                        AssetNo = a.AssetNo,
                        AssetModel = a.AssetModel,
                        ImageURL= a.ImageURL,
                        AssetName = a.AssetName,
                        Status = a.Status,
                        AssertQuantity = a.AssertQuantity,
                        AssetValue = a.AssetValue,
                        ManufacturingDate = a.ManufacturingDate,
                        ExpiryDate = a.ExpiryDate,
                        CategoryId = a.CategoryId,
                        IsAvailable = a.IsAvailable,

                    })
                    .ToListAsync();
                return assert;

            }
            catch (Exception ex) { throw new Exception($"Error while getting through AssertNo:{ex.Message}"); }
        }
        //To Get Assert By Assert Status
        public async Task<List<AssertDTO>> AssertByStatus(string status)
        {
            try
            {
                var assert = await _context.Asserts.Where(a=> a.Status.ToLower().Contains(status.ToLower()) && a.IsAvailable)
                    .Select(a=> new AssertDTO
                    {
                        AssetId = a.AssetId,
                        AssetNo = a.AssetNo,
                        AssetModel = a.AssetModel,
                        ImageURL = a.ImageURL,
                        AssetName = a.AssetName,
                        Status = a.Status,
                        AssetValue = a.AssetValue,
                        AssertQuantity= a.AssertQuantity,
                        ManufacturingDate = a.ManufacturingDate,
                        ExpiryDate = a.ExpiryDate,
                        CategoryId = a.CategoryId,
                        IsAvailable = a.IsAvailable,
                    })
                    .ToListAsync(); 
                return assert;

            }
            catch (Exception ex) { throw new Exception($"{ex.Message}"); }
        }
        //To Create a New Assert
        public async Task<string> Create(CreateAssertDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    var newAssert = new Assert
                    {
                        AssetNo = dto.AssetNo,
                        AssetModel = dto.AssetModel,
                        ImageURL = dto.ImageURL,
                        AssetName = dto.AssetName,
                        Status = dto.Status,
                        AssetValue = dto.AssetValue,
                        AssertQuantity = dto.AssertQuantity,    
                        ManufacturingDate = dto.ManufacturingDate,
                        ExpiryDate = dto.ExpiryDate,
                        CategoryId = dto.CategoryId,
                        IsAvailable = true,
                    };
                    await _context.AddAsync(newAssert);
                    await _context.SaveChangesAsync();
                    return "....Assert Added Successfully....";
                }
                else
                {
                    return "Enter the Correct User Details!!";
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //To Update a Assert
        public async Task<string> Update(UpdateAssertDTO dto, int Id)
        {
            try
            {
                var exisAssert = await _context.Asserts.Where(a=> a.AssetId == Id).FirstOrDefaultAsync();
                if (exisAssert != null)
                {
                    exisAssert.AssetNo = dto.AssetNo;
                    exisAssert.AssetModel = dto.AssetModel;
                    exisAssert.ImageURL = dto.ImageURL;
                    exisAssert.AssetName = dto.AssetName;
                    exisAssert.Status = dto.Status;
                    exisAssert.AssetValue = dto.AssetValue;
                    exisAssert.AssertQuantity = dto.AssertQuantity;
                    exisAssert.ManufacturingDate = dto.ManufacturingDate;
                    exisAssert.ExpiryDate = dto.ExpiryDate;
                    exisAssert.CategoryId = dto.CategoryId;
                    exisAssert.IsAvailable = dto.IsAvailable;

                    await _context.SaveChangesAsync();
                    return $"....Assert With ID:{Id} Updated Successfully.... ";
                }
                else
                    return $"Assert with Id:{Id} NotFound!!";

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //To Delete a Request
        public async Task<string> Delete(int Id)
        {
            try
            {
                var assert = await _context.Asserts.Where(a=> a.AssetId==Id).FirstOrDefaultAsync();
                if (assert != null)
                {
                    assert.IsAvailable = false;
                    await _context.SaveChangesAsync();
                    return $"....Assert With ID:{Id} Removed....";
                }
                else
                    return "Assert With ID Not Found!!";

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
