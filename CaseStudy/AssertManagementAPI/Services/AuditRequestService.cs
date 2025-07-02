using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.AuditRequest;
using AssertManagementAPI.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AssertManagementAPI.Services
{
    public class AuditRequestService : IAuditRequestService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AuditRequestService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //To Get All Audit Request
        public async Task<List<AuditRequestDTO>> AllRequests()
        {
            try
            {
                var audit = await _context.AuditRequests.Where(a => a.IsActive)
                    .Select(a => new AuditRequestDTO
                    {
                        AuditRequestId = a.AuditRequestId,
                        AssetId = a.AssetId,
                        UserId = a.UserId,
                        AuditStatus = a.AuditStatus,
                        AuditDate = a.AuditDate,
                        IsActive = a.IsActive,
                    })
                    .ToListAsync();
                return audit;

            }
            catch (Exception ex) { throw new Exception($"Error while fetching Details:{ex.Message}"); }
        }
        //To Get Audit Request By ID
        public async Task<AuditRequestDTO> GetByRequestId(int Id)
        {
            try
            {
                var audit = await _context.AuditRequests.Where(a => a.AuditRequestId == Id && a.IsActive).FirstOrDefaultAsync();
                if (audit != null)
                {
                    return _mapper.Map<AuditRequestDTO>(audit);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex) { throw new Exception($"Error while fetching Details:{ex.Message}"); }
        }
        //To Create a New Audit Request
        public async Task<string> AddRequest(CreateAuditRequestDTO dto)
        {
            try
            {
                if (dto != null)
                {
                    var audit = new AuditRequest
                    {
                        AssetId = dto.AssetId,
                        UserId = dto.UserId,
                        AuditStatus = dto.AuditStatus,
                        AuditDate = dto.AuditDate,
                        IsActive = true,
                    };
                    await _context.AuditRequests.AddAsync(audit);
                    await _context.SaveChangesAsync();
                    return "....Audit-Request Added Successfully.... ";
                }
                else
                {
                    return "Enter the Required Details To Create a Request!! ";
                }
            }
            catch (Exception ex) { throw new Exception($"Error while Adding Request Details:{ex.Message}"); }


        }
        //To Update a Audit Request
        //public async Task<string> UpdateRequest(UpdateAuditRequestDTO dto,int Id)
        //{
        //    try
        //    {
        //        var user = await _context.AuditRequests.Where(a=> a.AuditRequestId==Id && a.IsActive).FirstOrDefaultAsync();
        //        if (user != null) 
        //        { 
        //            user.AssetId = dto.AssetId;
        //            user.UserId = dto.UserId;
        //            user.AuditStatus = dto.AuditStatus;
        //            user.AuditDate = dto.AuditDate;
        //            user.IsActive = dto.IsActive;
        //            await _context.SaveChangesAsync();
        //            return "....Request Updated Successully....";
        //        }
        //        else
        //        {
        //            return "Enter the required Details To Update Request";
        //        }
        //    }
        //    catch (Exception ex) { throw new Exception($"Error while Adding Request Details:{ex.Message}"); }
        //}
        //To Delete a Audit Request
        public async Task<string> DeleteRequest(int Id)
        {
            try
            {
                var audit = await _context.AuditRequests.Where(a => a.AuditRequestId == Id && a.IsActive).FirstOrDefaultAsync();
                if (audit != null)
                {
                    audit.IsActive = false;
                    await _context.SaveChangesAsync();
                    return "....Request Deleted Sucessully....";
                }
                else { return "ID Doest Exist or Deleted Already!!"; }
            }
            catch (Exception ex) { throw new Exception($"Error while Adding Request Details:{ex.Message}"); }

        }
        // To Update a Audit Request
        public async Task<string> UpdateRequest(UpdateAuditRequestDTO dto, int Id)
        {
            try
            {
                var auditRequest = await _context.AuditRequests
                    .Where(a => a.AuditRequestId == Id && a.IsActive)
                    .FirstOrDefaultAsync();

                if (auditRequest != null)
                {
                    auditRequest.AssetId = dto.AssetId;
                    auditRequest.UserId = dto.UserId;

                    // Check if status changed to "Verified"
                    bool isNewlyVerified = auditRequest.AuditStatus != "Verified" && dto.AuditStatus == "Verified";
                    auditRequest.AuditStatus = dto.AuditStatus;
                    auditRequest.AuditDate = dto.AuditDate;
                    auditRequest.IsActive = dto.IsActive;

                    // Only if newly verified, reduce asset quantity
                    if (isNewlyVerified)
                    {
                        var asset = await _context.Asserts
                            .Where(a => a.AssetId == dto.AssetId && a.IsAvailable)
                            .FirstOrDefaultAsync();

                        if (asset != null && asset.AssertQuantity > 0)
                        {
                            asset.AssertQuantity -= 1;

                            // Optional: make unavailable if quantity becomes 0
                            if (asset.AssertQuantity == 0)
                            {
                                asset.IsAvailable = false;
                            }
                        }
                        else
                        {
                            return "Asset not found or quantity is already 0.";
                        }
                    }

                    await _context.SaveChangesAsync();
                    return "....Request Updated Successfully....";
                }
                else
                {
                    return "Audit request not found or already inactive.";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating request: {ex.Message}");
            }

        }
    }
}
