using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Project
    {
        [Key]
        [Column(Order = 1)]
        public Guid Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name Required")]
        public string Name { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }

        public virtual ICollection<Discussion> Discussion { get; set; }
    }
}