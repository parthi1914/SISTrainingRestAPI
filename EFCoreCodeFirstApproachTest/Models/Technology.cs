using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstApproachTest.Models
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        public int TechnologyName { get; set; }
        public Department department  { get; set; }
    }
}
