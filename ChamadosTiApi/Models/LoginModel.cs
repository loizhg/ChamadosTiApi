using Microsoft.AspNetCore.Http;
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
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
