using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Task Name")]
        [Required(ErrorMessage = "Task Name Required")]
        public string Name { get; set; }

        [DisplayName("State")]
        [Required(ErrorMessage = "State Required")]
        public string State { get; set; }

        [DisplayName("Assigned To")]
        [Required(ErrorMessage = "Assigned To Required")]
        public string AssignedTo { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [DisplayName("Difficulty")]
        [Required(ErrorMessage = "Difficulty Required")]
        public int Difficulty { get; set; }
    }
}