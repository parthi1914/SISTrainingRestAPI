using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstApproachTest.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public int DepartmentName { get; set; }
        public int DepartmentLocation { get; set; }
    }
}
