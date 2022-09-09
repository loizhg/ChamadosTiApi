using System;
using System.Collections.Generic;
using System.Text;

namespace ChamadosTiClient.Dtos
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
