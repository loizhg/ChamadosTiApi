﻿using Microsoft.AspNetCore.Http;
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
    public class ChamadosController : ControllerBase
    {
        public ChamadoRepository chamadorepositorio = new ChamadoRepository();

        [HttpPost]
        public IActionResult Save(Chamado chamado)
        {
            var cham = chamadorepositorio.SalvarChamado(chamado);

            if (cham)
                return Ok("Adicionado com sucesso!");


            return NoContent();

        }

        [HttpGet]
        public IActionResult SearchById(int idUsuarioValidado)
        {
            var resultado = chamadorepositorio.BuscarTodos(idUsuarioValidado);

            if (resultado == null || !resultado.Any())
                return NotFound(new { mensage = $"Lista vazia." });

            return Ok(resultado);
       }
    }
}
