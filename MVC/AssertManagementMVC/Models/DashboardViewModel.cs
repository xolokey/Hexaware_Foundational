namespace AssetManagementMVC.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }
        public int TotalAssets { get; set; }
        public int AllocatedAssets { get; set; }
        public int ActiveRequests { get; set; }
        public int PendingAudits { get; set; }
    }
}
