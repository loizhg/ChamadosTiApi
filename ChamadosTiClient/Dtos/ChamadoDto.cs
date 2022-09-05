using System;
using System.Collections.Generic;
using System.Text;

using ChamadosTiClient.Models;
using ChamadosTiClient.Service;

namespace ChamadosTiClient.Dtos
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
