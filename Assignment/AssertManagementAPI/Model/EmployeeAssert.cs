namespace AssertManagementAPI.Model
{
    public class EmployeeAssert
    {
        public int AllocationId {  get; set; }
        public required int UserId {  get; set; }
        public virtual User? User { get; set; }
        public required int AssertId { get; set; }
        public virtual Assert? Assert { get; set; }
        public required DateTime AllocationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Status {  get; set; }=true;
    }
}
