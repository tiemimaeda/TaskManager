using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    [Table("APPLICATION")]
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Application")]
        [Required(ErrorMessage = "Required field.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Url")]
        [Required(ErrorMessage = "Required field.")]
        public string Url { get; set; }

        public bool Status { get; set; }
    }
}
