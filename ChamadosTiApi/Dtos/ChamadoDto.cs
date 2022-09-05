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
    public class ChamadoDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public int Importancia { get; set; }
        public int ChamadoLivre { get; set; }
        public int ChamadoResolvido { get; set; }


    }
}
