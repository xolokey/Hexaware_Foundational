using Department.Models;


namespace Department.Repository
{
    public class DepartmetService : IDepartmentService
    {
        public static List<SubDepartment> departments = new List<SubDepartment>()
            {
                new SubDepartment{DepartmentId=1,DepartmentName="Python",DepartmentCategory="Programing",DepartmentLocation="New Complex"},
                new SubDepartment{DepartmentId=2,DepartmentName="Java",DepartmentCategory="Programming",DepartmentLocation="Old Complex"}
            };

        public List<SubDepartment> GetAllDepartments()
        {
            return departments;
        }

        public int CreateDepartment(SubDepartment department)
        {
            if (department != null)
            {
                departments.Add(department);
                return department.DepartmentId; 
            }
            else
                return 0;
        }

        public SubDepartment GetDepartment(int departmentId)
        {
            var department= departments.Where(d=> d.DepartmentId==departmentId).FirstOrDefault();
            if (department == null)
            {

                return null;
            }
            else
            {
                return department;
            }
        }
        public string UpdateDepartment(SubDepartment department)
        {
            var index = departments.FindIndex(d=> d.DepartmentId == department.DepartmentId);
            if (index != -1)
            {
                departments[index] = department;
                return $"Department {department.DepartmentName} Updated Successfully ";
            }
            else
            {
                return $"Department{department.DepartmentName} not found";
            }

        }

        public string DeleteDepartment(int DepartmentId)
        {
            var department = departments.Where(d=> d.DepartmentId==DepartmentId).FirstOrDefault();
            if (department != null) 
            {
                departments.Remove(department);
                return $"{department.DepartmentName} {department.DepartmentId} Removed!";
            }
            else
            {

                return $"{department.DepartmentId} Not Found";
            }
        }
    }
}
