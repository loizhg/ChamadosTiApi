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
    public class AtendimentoRepository
    {
        //private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=ProjetoFinalDB;Integrated Security=True";
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=chamadosDB;Integrated Security=True";

        public bool SalvarAtendimento(Atendimento atendimento)
        {

            try
            {

                var query = @"INSERT INTO atendimento(IdChamado, IdTecnico, DataAtribuido, DataEstimada, AtendimentoResolvido)                               
                              VALUES (@idchamado, @idtecnico, @dataatribuido, @dataestimada, @atendimentoresolvido)";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idchamado", atendimento.IdChamado);
                    command.Parameters.AddWithValue("@idtecnico", atendimento.IdTecnico);
                    command.Parameters.AddWithValue("@dataatribuido", atendimento.DataAtribuido);
                    command.Parameters.AddWithValue("@dataestimada", atendimento.DataEstimada);
                    command.Parameters.AddWithValue("@atendimentoresolvido", atendimento.AtendimentoResolvido);



                    command.Connection.Open();
                    command.ExecuteScalar();
                }


                Console.WriteLine("Atendimento cadastrada com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<ChamadoDto> BuscarTodos()
        {
            List<ChamadoDto> chamadosEncontrados;
            try
            {
                var query = @"SELECT * FROM atendimento";

                using (var connection = new SqlConnection(_connection))
                {
                    chamadosEncontrados = connection.Query<ChamadoDto>(query).ToList();
                }

                return chamadosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool FinalizarAtendimento(int Id)
        {
            try
            {
                var query = @$"UPDATE atendimento SET AtendimentoResolvido = 1 WHERE Id = @Id";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Chamado atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }
    }
}
