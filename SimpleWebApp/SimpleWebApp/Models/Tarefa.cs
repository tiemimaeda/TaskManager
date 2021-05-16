using System;
using System.Collections.Generic;
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
}
