using System.ComponentModel.DataAnnotations;

namespace EF_CodeFirstDemo.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        

    }
}
