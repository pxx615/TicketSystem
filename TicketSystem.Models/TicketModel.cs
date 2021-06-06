using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TicketSystem.Models.Resources;

namespace TicketSystem.Models
{
    public class TicketModel
    {
        public int TicketId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorText), ErrorMessageResourceName = "Error_projectName")]
        [Display(Name = "Project name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorText), ErrorMessageResourceName = "Error_department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorText), ErrorMessageResourceName = "Error_employee")]
        [Display(Name = "Requested by")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorText), ErrorMessageResourceName = "Error_description")]
        [Display(Name = "Description of Problem")]
        public string Description { get; set; }

        public System.DateTime DateTime { get; set; }

        public DepartmentModel Department { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
