﻿using System;
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

        public List<ChamadoDto> BuscarTodos(int idUsuarioValidado)
        {
            List<ChamadoDto> chamadosEncontrados;
            try
            {
                var query = @$"SELECT * FROM chamado";

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
    }
}
