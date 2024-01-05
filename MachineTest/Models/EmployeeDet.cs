using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MachineTest.Models
{
    public class EmployeeDet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Employee Name is Required")]
        [Display(Name = "Employee Name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Department is required")]
        [Display(Name = "Department Name")]
        [StringLength(50)] 
        public string Department { get; set; }
    }
}