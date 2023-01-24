using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogMiddleware.Api.data.Interface;
using LogMiddleware.Api.Models;

namespace LogMiddleware.Api.data.Implementation
{
    public class UsuarioRep : Repositorio<Usuario>, IUsuarioRep
    {
        public UsuarioRep(IConfiguration configuration) : base(configuration)
        { }

    }
}