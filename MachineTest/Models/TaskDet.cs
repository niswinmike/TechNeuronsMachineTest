using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MachineTest.Models
{
    public class TaskDet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Task Name is Required")]
        [Display(Name = "Task Name")]
        [StringLength(50)]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [Display(Name = "Description")]
        [StringLength(150)]
        public string Description { get; set; }
    }
}