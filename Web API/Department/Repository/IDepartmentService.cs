using Department.Models;
namespace Department.Repository
{
    public interface IDepartmentService
    {
        public List<SubDepartment> GetAllDepartments();
        public int CreateDepartment(SubDepartment department);
        public string UpdateDepartment(SubDepartment department);
        public string DeleteDepartment(int DepartmentId);
        public SubDepartment GetDepartment(int DepartmentId);
    }
}
