using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Discussion
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Comment")]
        [Required(ErrorMessage = "Comment Required")]
        public string Comment { get; set; }
    }
}