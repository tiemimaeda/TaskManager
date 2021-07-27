using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Models
{
    public class Usuario
    {
        [Key]
        [Column("USUARIO_ID")]
        public int Id { get; set; }

        [Column("USUARIO_NOME")]
        public string Nome { get; set; }

        [Column("USUARIO_EMAIL")]
        public string Email { get; set; }

        [Column("USUARIO_SENHA")]
        public string Senha { get; set; }

        [Column("USUARIO_STATUS")]
        public bool Status { get; set; }
    }

    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}
