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
    public class ChamadoRepository
    {
        //private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=ProjetoFinalDB;Integrated Security=True";
        private readonly string _connection = @"Data Source=DESKTOP-88BTRFG\SQLEXPRESS;Initial Catalog=chamadosDB;Integrated Security=True";

        public bool SalvarChamado(Chamado chamado)
        {

            try
            {


                var query = @"INSERT INTO Chamado(IdUsuario, Descricao, Importancia, ChamadoLivre, ChamadoResolvido)                               
                              VALUES (@idusuario, @descricao, @importancia, @chamadolivre, @chamadoresolvido)";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@idusuario", chamado.IdUsuario);
                    command.Parameters.AddWithValue("@descricao", chamado.Descricao);
                    command.Parameters.AddWithValue("@importancia", chamado.Importancia);
                    command.Parameters.AddWithValue("@chamadolivre", chamado.ChamadoLivre);
                    command.Parameters.AddWithValue("@chamadoresolvido", chamado.ChamadoResolvido);

                    command.Connection.Open();
                    command.ExecuteScalar();
                }


                Console.WriteLine("Chamado cadastrada com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<ChamadoDto> BuscarPorId(int IdUsuario)
        {
            List<ChamadoDto> chamadosEncontrados;
            try
            {
                var query = @$"SELECT * FROM chamado where IdUsuario = {IdUsuario} ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);                                      
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

        public List<ChamadoDto> BuscarDisponiveis()
        {
            List<ChamadoDto> chamadosEncontrados;
            try
            {
                var query = @$"SELECT * FROM chamado where ChamadoLivre = 0 ";

                using (var connection = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, connection);
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


        public bool UpdateChamado(int Id)
        {
            try
            {
                var query = @$"UPDATE chamado SET ChamadoLivre = 1 WHERE Id = @Id";
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
