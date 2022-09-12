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
    public class AtendimentosController : ControllerBase
    {

        public AtendimentoRepository atendimentorepositorio = new AtendimentoRepository();

        [HttpPost]
        public IActionResult Save(Atendimento atendimento)
        {
            var cham = atendimentorepositorio.SalvarAtendimento(atendimento);

            if (cham)
                return Ok("Adicionado com sucesso!");


            return NoContent();

        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var resultado = atendimentorepositorio.BuscarTodos();

            if (resultado == null || !resultado.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(resultado);
        }

        [HttpPut]
        public IActionResult Finish(int Id)
        {

            var resultado = atendimentorepositorio.FinalizarAtendimento(Id);

            if (resultado) return Ok("Servico atualizado com sucesso. ");
            return Ok(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar o servico."
            });
        }
    }
}
