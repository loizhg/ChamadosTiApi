using System;
using System.Collections.Generic;
using System.Text;

using ChamadosTiClient.Dtos;
using ChamadosTiClient.Service;

namespace ChamadosTiClient.Models
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }        
        public int Unidade { get; set; }

        public Usuario() { }

        
    }
}
