using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Controllers;
using ChamadosTiApi.Dtos;
using ChamadosTiApi.Models;
using ChamadosTiApi.ViewModels;

using System.Data.SqlClient;
using Dapper;

namespace ChamadosTiApi.Repositories
{
    public class AtendimentoDetalhadoRepository
    {
        //private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=ProjetoFinalDB;Integrated Security=True";
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=chamadosDB;Integrated Security=True";


        public List<AtendimentoDetalhadoDto> BuscarPorIdUsuario(int IdUsuario)
        {
            List<AtendimentoDetalhadoDto> atendimentosEncontrados;
            try
            {
                var query = @$"SELECT a.Id, a.IdChamado, a.IdTecnico, a.DataAtribuido, a.DataEstimada, a.AtendimentoResolvido, a.DataResolucao,
                                c.Descricao as Descricao, 
                                c.IdUsuario as IdUsuario,
                                p.Nome  as Nome
                                FROM Atendimento a
                                  INNER JOIN Atendimento s 
							      ON s.Id = a.Id
                                  INNER JOIN Chamado c 
							      ON c.Id = a.IdChamado
							      INNER JOIN Usuario p 
							      ON p.Id = a.IdTecnico
							        where c.IdUsuario = {IdUsuario} and a.AtendimentoResolvido = 1";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    atendimentosEncontrados = connection.Query<AtendimentoDetalhadoDto>(query).ToList();

                }

                return atendimentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public List<AtendimentoDetalhadoDto> BuscarPorIdTecnico(int IdUsuario)
        {
            List<AtendimentoDetalhadoDto> atendimentosEncontrados;
            try
            {
                var query = @$"SELECT a.Id, a.IdChamado, a.IdTecnico, a.DataAtribuido, a.DataEstimada, a.AtendimentoResolvido, a.DataResolucao,
                                c.Descricao as Descricao, 
                                c.IdUsuario as IdUsuario,
                                p.Nome  as Nome
                                FROM Atendimento a
                                  INNER JOIN Atendimento s 
							      ON s.Id = a.Id
                                  INNER JOIN Chamado c 
							      ON c.Id = a.IdChamado
							      INNER JOIN Usuario p 
							      ON p.Id = a.IdTecnico
							        where a.IdTecnico = {IdUsuario} and a.AtendimentoResolvido = 0";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    atendimentosEncontrados = connection.Query<AtendimentoDetalhadoDto>(query).ToList();

                }

                return atendimentosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
    }
}
