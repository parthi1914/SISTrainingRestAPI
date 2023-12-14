using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstApproachTest.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
      
        public string Designation
        {
            get;
            set;
        }

        public string bonus
        {
            get;
            set;
        }
    }
}
