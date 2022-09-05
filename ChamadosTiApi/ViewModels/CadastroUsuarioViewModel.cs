using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Controllers;
using ChamadosTiApi.Dtos;
using ChamadosTiApi.Models;
using ChamadosTiApi.Repositories;

using System.Data.SqlClient;
using Dapper;

namespace ChamadosTiApi.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        public Usuario Usuario { get; set; }
    }
}
