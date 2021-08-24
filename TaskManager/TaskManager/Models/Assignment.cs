using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    [Table("ASSIGNMENT")]
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "DateTime")]
        [Display(Name = "Date of Request")]
        [Required(ErrorMessage = "Required field.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RequestedDate { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "Required field.")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required field.")]
        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Complexity")]
        public int Complexity { get; set; }

        [Display(Name = "Application")]
        [Required(ErrorMessage = "Required field.")]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }

        public bool Status { get; set; }

    }
}
