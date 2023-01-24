using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogMiddleware.Api.Models
{
    public class Usuario
    {

        public Usuario(){}
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}