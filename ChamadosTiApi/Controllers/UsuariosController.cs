using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Dtos;
using ChamadosTiApi.Models;
using ChamadosTiApi.Repositories;
using ChamadosTiApi.ViewModels;

namespace ChamadosTiApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //private static readonly List<Usuario> usuarios = new List<Usuario>();


        //public UsuarioRepository usuariorepositorio = new UsuarioRepository();
        //private readonly UsuarioRepository usuarioRepositorio;

        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Save(Usuario usuario)
        {
            if (usuario == null)
                return NoContent();

            _usuarioRepository.SalvarUsuario(usuario);

            return Ok("Adicionado com sucesso!");
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var resultado = _usuarioRepository.BuscarTodos();

            if (resultado == null || !resultado.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(resultado);
        }

        [HttpDelete]
        public IActionResult Delete(CadastroUsuarioViewModel deleteUsuario)
        {
            var resultado = _usuarioRepository.DeleteUsuario(deleteUsuario.Usuario);

            if (resultado) return Ok("Cliente removido com sucesso.");

            return Ok("Erro ao deletar o cliente.");
        }

        [HttpPost]
        public IActionResult Logar(LoginModel loginModel)
        {
            var resultado = _usuarioRepository.EfetuarLogin(loginModel);

            if (resultado == null)
                return NotFound(new { mensage = $"Usuario não existe." });

            return Ok(resultado);
        }
        
    }
}
