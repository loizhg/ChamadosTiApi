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
    public class UsuarioRepository
    {
        private readonly string _connection = @"Data Source=ITELABD13\SQLEXPRESS;Initial Catalog=ProjetoFinalDB;Integrated Security=True";
        private object command;

        public bool SalvarUsuario(Usuario usuario)
        {

            try
            {

                //INSERT INTO usuario (Login, Password, Nivel, Nome, Data_Nascimento, Unidade)
                //VALUES('loizhg', 'senha', 1, 'Luiz', '12-03-1996', 1);

                var query = @"INSERT INTO usuario(Login, Password, Nivel, Nome, DataNascimento, Unidade)                               
                              VALUES (@login, @password, @nivel, @nome, @data_nascimento, @unidade)";
                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@login", usuario.Login);
                    command.Parameters.AddWithValue("@password", usuario.Password);
                    command.Parameters.AddWithValue("@nivel", usuario.Nivel);
                    command.Parameters.AddWithValue("@nome", usuario.Nome);
                    command.Parameters.AddWithValue("@data_nascimento", usuario.DataNascimento);
                    command.Parameters.AddWithValue("@unidade", usuario.Unidade);
                    command.Connection.Open();
                    command.ExecuteScalar();

                }


                Console.WriteLine("Pessoa cadastrada com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return false;
            }
        }

        public List<UsuarioDto> BuscarTodos()
        {
            List<UsuarioDto> usuariosEncontrados;
            try
            {
                var query = @"SELECT * FROM Usuario";

                using (var connection = new SqlConnection(_connection))
                {
                    usuariosEncontrados = connection.Query<UsuarioDto>(query).ToList();
                }



                return usuariosEncontrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }

        public bool DeleteUsuario(Usuario usuario)
        {
            try
            {
                var query = @"DELETE FROM usuario WHERE Id = @Id";


                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Id", usuario.Id);
                    command.Connection.Open();
                    command.ExecuteScalar();
                }

                Console.WriteLine("Usuario Removido com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Usuario EfetuarLogin(LoginModel loginModel)
        {
            SqlDataReader resultado;



            try
            {
                var query = @"SELECT * FROM Usuario WHERE Login = @Login AND Password = @Password";

                using (var sql = new SqlConnection(_connection))
                {
                    SqlCommand command = new SqlCommand(query, sql);
                    command.Parameters.AddWithValue("@Login", loginModel.Login);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);
                    command.Connection.Open();
                    resultado = command.ExecuteReader();

                    var usuario = new Usuario()
                    {
                        Id = resultado.GetInt32(0),
                        Login = resultado.GetString(1),
                        Password = resultado.GetString(2),
                        Nivel = resultado.GetInt32(3),
                        Nome = resultado.GetString(4),
                        DataNascimento = resultado.GetDateTime(5),
                        Unidade = resultado.GetInt32(6),
                    };


                    return usuario;

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return null;
            }
        }
    }
}
