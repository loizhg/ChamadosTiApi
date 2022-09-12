﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Dtos;
using ChamadosTiApi.Controllers;
using ChamadosTiApi.Repositories;
using ChamadosTiApi.ViewModels;

namespace ChamadosTiApi.Models
{
    public class AtendimentoDetalhado
    {
        public int Id { get; set; }
        public int IdChamado { get; set; }
        public int IdTecnico { get; set; }
        public DateTime DataAtribuido { get; set; }
        public DateTime DataEstimada { get; set; }
        public int AtendimentoResolvido { get; set; }
        public DateTime DataResolucao { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }
    }
}
