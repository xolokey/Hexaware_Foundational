using AssertManagementAPI.Context;
using AssertManagementAPI.DTO.ServiceRequest;
using AssertManagementAPI.Model.AssetManagementAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AssertManagementAPI.Services
{
    public class ServiceRequestService:IServiceRequestService
    {
        //Calling Dbcontext and Mapper
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ServiceRequestService(AppDbContext context,IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }
        //To Get All Service Request
        public async Task<List<ServiceRequestDTO>> GetServiceRequests()
        {
            try
            {
                var service = await _context.ServiceRequests.Where(s => s.IsActive)
                    .Select(s => new ServiceRequestDTO
                    {
                        RequestId = s.RequestId,
                        Description = s.Description,
                        IssueType = s.IssueType,
                        Status = s.Status,
                        RequestedDate = s.RequestedDate,
                        ResolvedDate = s.ResolvedDate,
                        AssetId = s.AssetId,
                        UserId = s.UserId,
                        IsActive = s.IsActive,
                    })
                    .ToListAsync();
                return service;
            }
            catch (Exception ex) { throw new Exception($"Error while fetching Service Details:{ex.Message}"); }
        }
        //To Get Service Request By ID
        public async Task<ServiceRequestDTO> GetServiceRequestById(int Id)
        {
            try
            {
                var service = await _context.ServiceRequests.Where(s=> s.RequestId == Id && s.IsActive).FirstOrDefaultAsync();
                if (service != null)
                {
                    return _mapper.Map<ServiceRequestDTO>(service);
                }
                else
                    return null;

            }
            catch (Exception ex) { throw new Exception($"Error while fetching Service Details:{ex.Message}"); }
        }
        //To Create a new Service Request
        public async Task<string> CreateRequest(CreateServiceResquestDTO serviceReq)
        {
            try
            {
                if (serviceReq != null)
                {
                    var service = new ServiceRequest
                    {
                        Description = serviceReq.Description,
                        IssueType = serviceReq.IssueType,
                        Status = serviceReq.Status,
                        RequestedDate = serviceReq.RequestedDate,
                        ResolvedDate = serviceReq.ResolvedDate,
                        AssetId = serviceReq.AssetId,
                        UserId = serviceReq.UserId,
                        IsActive = true,
                    };
                    await _context.ServiceRequests.AddAsync(service);
                    await _context.SaveChangesAsync();
                    return "....New Service Request Created succefully....";
                }
                else
                    return "Enter the required Details to Register a Request!!";
            }
            catch (Exception ex) { throw new Exception($"Error while Creating Service Request:{ex.Message}"); }
        }
        //To Update a Service Request
        public async Task<string> UpdateRequest(UpdateServiceRequestDTO serviceReq,int Id)
        {
            try
            {
                var service = await _context.ServiceRequests.Where(s=> s.RequestId==Id && s.IsActive).FirstOrDefaultAsync();
                if (service != null)
                {
                    service.Description = serviceReq.Description;
                    service.IssueType = serviceReq.IssueType;
                    service.Status = serviceReq.Status;
                    service.RequestedDate = serviceReq.RequestedDate;
                    service.ResolvedDate = serviceReq.ResolvedDate;
                    service.AssetId = serviceReq.AssetId;
                    service.UserId = serviceReq.UserId;
                    service.IsActive = serviceReq.IsActive;
                    await _context.SaveChangesAsync();
                    return "....Service Request Updated Successffully....";
                }
                else { return $"No Request With ID:{Id} Avilable!!"; }

            }
            catch (Exception ex) { throw new Exception($"Error while Updating Service Request:{ex.Message}"); }
        }
        //To Delete the service Request
        public async Task<string> DeleteRequest(int Id)
        {
            try
            {
                var service = await _context.ServiceRequests.Where(s=> s.RequestId == Id).FirstOrDefaultAsync();
                if(service != null)
                {
                    service.IsActive= false;
                    await _context.SaveChangesAsync();
                    return "....Service Request Deleted Successfully....";
                }
                else { return $"Service Request With ID : {Id} NotFound!!"; }
            }
            catch (Exception ex) { throw new Exception($"Error while Updating Service Request:{ex.Message}"); }
        }
    }
}
