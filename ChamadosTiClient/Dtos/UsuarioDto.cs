using System;
using System.Collections.Generic;
using System.Text;

using ChamadosTiClient.Models;
using ChamadosTiClient.Service;

namespace ChamadosTiClient.Dtos
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
