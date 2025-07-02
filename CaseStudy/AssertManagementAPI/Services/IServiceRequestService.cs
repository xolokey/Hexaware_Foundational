
using AssertManagementAPI.DTO.ServiceRequest;

namespace AssertManagementAPI.Services
{
    public interface IServiceRequestService
    {
        public Task<List<ServiceRequestDTO>> GetServiceRequests();
        public Task<ServiceRequestDTO> GetServiceRequestById(int Id);
        public Task<string> CreateRequest(CreateServiceResquestDTO serviceReq);
        public Task<string> UpdateRequest(UpdateServiceRequestDTO serviceReq,int Id);
        public Task<string> DeleteRequest(int Id);

    }
}
