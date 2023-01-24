using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LogMiddleware.Api.Attributes;
using LogMiddleware.Api.data.Interface;
using LogMiddleware.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace LogMiddleware.Api.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRep _usuarioRep;

        public UsuarioController(IUsuarioRep usuarioRep)
        {
            _usuarioRep = usuarioRep;
        }

        [HttpPost, Route("InserirUsuario")]
        public async Task<IActionResult> InserirUsuario([FromBody] Usuario usuario)
        {
            return Ok(await _usuarioRep.Insert("insert into usuario values (@Id, @Nome, @CPF)", usuario));
        }

        [HttpGet, Route("ObterTodosUsuarios")]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            return Ok(await _usuarioRep.ObterTodos("SELECT * FROM USUARIO"));
        }

        [HttpGet, Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _usuarioRep.ObterPorId("SELECT * FROM USUARIO Where id = @id", new { id = id }));
        }

        [HttpPut, Route("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] Usuario usuario)
        {
            return Ok(await _usuarioRep.Update("UPDATE USUARIO SET nome = @Nome, CPF =@CPF Where id = @id", usuario));
        }


    }
}