using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Models
{
    public class Aplicacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public bool Status { get; set; }
    }

    public class AplicacaoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Aplicação")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Url")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string Url { get; set; }

        public bool Status { get; set; }
    }
}
