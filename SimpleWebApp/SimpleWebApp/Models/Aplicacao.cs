using System;
using System.Collections.Generic;
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
}
