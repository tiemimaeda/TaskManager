using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApp.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public DateTime DataSolitacao { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Complexidade { get; set; }
        public int AplicacaoId { get; set; }
        public virtual Aplicacao Aplicacao { get; set; }
        public bool Status { get; set; }

    }

    public class TarefaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Data da Solicitação")]
        public DateTime DataSolitacao { get; set; }

        public int UsuarioId { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string Descricao { get; set; }

        [Display(Name = "Data Início")]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Data Fim")]
        public DateTime? DataFim { get; set; }

        [Display(Name = "Complexidade")]
        public int Complexidade { get; set; }

        public int AplicacaoId { get; set; }

        [Display(Name = "Aplicação")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public virtual Aplicacao Aplicacao { get; set; }
        public bool Status { get; set; }
    }
}
