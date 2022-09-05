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
    public class UsuarioDto
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Unidade { get; set; }

    }
}
