using System;
using System.Collections.Generic;
using System.Text;

namespace ChamadosTiClient.Dtos
{
    internal class AtendimentoDetalhadoDto
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
