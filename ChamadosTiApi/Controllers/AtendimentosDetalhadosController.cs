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
    public class AtendimentosDetalhadosController : ControllerBase
    {
        public AtendimentoDetalhadoRepository atendimentodetalhadorepositorio = new AtendimentoDetalhadoRepository();

        public IActionResult SearchByIdUser(int IdUsuario)
        {
            var resultado = atendimentodetalhadorepositorio.BuscarPorIdUsuario(IdUsuario);

            if (resultado == null || !resultado.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(resultado);
        }

        public IActionResult SearchByIdTecnic(int IdUsuario)
        {
            var resultado = atendimentodetalhadorepositorio.BuscarPorIdTecnico(IdUsuario);

            if (resultado == null || !resultado.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(resultado);
        }

       
    }
}


