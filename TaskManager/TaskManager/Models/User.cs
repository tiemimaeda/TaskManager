using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    [Table("USER")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "User")]
        [Required(ErrorMessage = "Required field.")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required field.")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Required field.")]
        public string Password { get; set; }

        public bool Status { get; set; }
    }
}
