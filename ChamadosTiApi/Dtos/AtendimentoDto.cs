using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Controllers;
using ChamadosTiApi.Models;
using ChamadosTiApi.Repositories;
using ChamadosTiApi.ViewModels;

namespace ChamadosTiApi.Dtos
{
    public class AtendimentoDto
    {
        public int Id { get; set; }
        public int IdChamado { get; set; }
        public int IdTecnico { get; set; }
        public DateTime DataAtribuido { get; set; }
        public DateTime DataEstimada { get; set; }
        public int AtendimentoResolvido { get; set; }
        public DateTime DataResolucao { get; set; }
    }
}
