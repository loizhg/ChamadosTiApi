using System;
using System.Collections.Generic;
using System.Text;

using ChamadosTiClient.Dtos;
using ChamadosTiClient.Service;

namespace ChamadosTiClient.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Descricao { get; set; }
        public int Importancia { get; set; }
        public int ChamadoLivre { get; set; }
        public int ChamadoResolvido { get; set; }

        public Chamado() { }
    }
}
