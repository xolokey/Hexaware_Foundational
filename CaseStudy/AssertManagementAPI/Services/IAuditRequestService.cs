using AssertManagementAPI.DTO.AuditRequest;

namespace AssertManagementAPI.Services
{
    public interface IAuditRequestService
    {
        public Task<List<AuditRequestDTO>> AllRequests();
        public Task<AuditRequestDTO> GetByRequestId(int Id);
        public Task<string> AddRequest(CreateAuditRequestDTO dto);
        public Task<string> UpdateRequest(UpdateAuditRequestDTO dto, int Id);
        public Task<string> DeleteRequest(int Id);
    }
}
