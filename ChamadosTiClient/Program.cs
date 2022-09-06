using ChamadosTiClient.Models;
using ChamadosTiClient.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ChamadosTiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //VARIAVEIS PARA AS OPÇÕES DE INTERFACE
            int opcaoDeslogado = -1;
            int opcaoLogado = -1;
            int opcaoChamado = -1;
            int chamadoEscolhido = -1;

            bool logado = true;
            int niveldoUsuario = 1;
            int idUsuarioValidado = 5;

            //INSTANCIAS NECESSÁRIAS 
            var usuarioService = new UsuarioService();
            var chamadoService = new ChamadoService();

            //OPÇÕES APOS O LOGIN
            if (logado)
            {
                //OPÇÕES DE USUARIO NORMAL
                if (niveldoUsuario == 0)
                {
                    do
                    {
                        Console.WriteLine("O que você gostaria de fazer? ");
                        Console.WriteLine("\n 1 - Cadastrar um chamado");
                        Console.WriteLine("\n 2 - Visualizar meus chamados");
                        Console.WriteLine("\n 0 - Deslogar");
                        opcaoLogado = Convert.ToInt32(Console.ReadLine());

                        if (opcaoLogado == 1)
                        {
                            //VARIAVEIS NESCESSÁRIAS PARA UM CADASTRO DE CHAMADO                                          
                            int idUsuario;
                            string descricao;
                            int importancia;
                            int chamadoLivre;
                            int chamadoResolvido;

                            //FORMULARIO PARA CADASTRO DE USUARIO
                            Console.WriteLine("Insira os dados para a criação do chamado: ");
                            Console.WriteLine($"\n IdUsuario: {idUsuarioValidado}");
                            idUsuario = idUsuarioValidado;
                            Console.WriteLine("\n Descricao:");
                            descricao = Convert.ToString(Console.ReadLine());
                            Console.WriteLine("\n Importancia:");
                            Console.WriteLine("\n Diga o nivel do seu problema de 1 a 5: ");
                            importancia = Convert.ToInt32(Console.ReadLine());
                            chamadoLivre = 0;
                            chamadoResolvido = 0;


                            var chamado = new Chamado()
                            {
                                IdUsuario = idUsuario,
                                Descricao = descricao,
                                Importancia = importancia,
                                ChamadoLivre = chamadoLivre,
                                ChamadoResolvido = chamadoResolvido,
                            };

                            chamadoService.Cadastrar(chamado);
                            Console.WriteLine("\n Chamado cadastrado com sucesso.");
                        }

                        if (opcaoLogado == 2)
                        {
                            var resultado = chamadoService.ListarChamados(idUsuarioValidado);
                            //mostra os dados na tela                    
                            foreach (var chamado in resultado)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n=====================================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Id: " + chamado.Id);
                                Console.WriteLine("Descricao: " + chamado.Descricao);
                                Console.WriteLine("Importancia: " + chamado.Importancia);
                                Console.WriteLine("ChamadoLivre: " + chamado.ChamadoLivre);
                                Console.WriteLine("ChamadoResolvido: " + chamado.ChamadoResolvido);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("=====================================");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }

                    } while (opcaoLogado != 0);
                }

                if (niveldoUsuario == 1)
                {
                    do
                    {
                        Console.WriteLine("O que você gostaria de fazer? ");
                        Console.WriteLine("\n 1 - Visualizar chamados disponiveis");
                        Console.WriteLine("\n 2 - Visualizar chamados em atividade");
                        Console.WriteLine("\n 0 - Deslogar");
                        opcaoLogado = Convert.ToInt32(Console.ReadLine());

                        if (opcaoLogado == 1)
                        {
                            var resultado = chamadoService.ListarChamadosDisponiveis();
                            //mostra os dados na tela                    
                            foreach (var chamado in resultado)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\n=====================================");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Id: " + chamado.Id);
                                Console.WriteLine("Descricao: " + chamado.Descricao);
                                Console.WriteLine("Importancia: " + chamado.Importancia);
                                Console.WriteLine("ChamadoLivre: " + chamado.ChamadoLivre);
                                Console.WriteLine("ChamadoResolvido: " + chamado.ChamadoResolvido);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("=====================================");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            do
                            {
                                Console.WriteLine("Você gostaria de realizar um atendimento? ");
                                Console.WriteLine("\n 1 - Selecionar um chamado");
                                Console.WriteLine("\n 0 - Retornar para menu anterior");
                                opcaoChamado = Convert.ToInt32(Console.ReadLine());

                                if (opcaoChamado == 1) 
                                {
                                    Console.WriteLine("Escolha o id do chamado que você gostaria de atender: ");
                                    chamadoEscolhido = Convert.ToInt32(Console.ReadLine());                                    
                                    chamadoService.Atualizar(chamadoEscolhido);
                                }

                            } while (opcaoChamado != 0);

                        }

                        if (opcaoLogado == 2)
                        {

                        }

                    } while (opcaoLogado != 0);
                }
            }


            if (logado == false)
            {
                do
                {
                    Console.WriteLine("O que você gostaria de fazer? ");
                    Console.WriteLine("\n 1 - Efetuar login");
                    Console.WriteLine("\n 2 - Cadastrar um usuario");
                    Console.WriteLine("\n 0 - Sair do sistema");
                    opcaoDeslogado = Convert.ToInt32(Console.ReadLine());

                    if (opcaoDeslogado == 1)
                    {
                        Console.WriteLine("Efetuar login");
                        string login;
                        string password;
                        Console.WriteLine("Insira os dados do usuario:");
                        Console.WriteLine("\n Login:");
                        login = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\n Password:");
                        password = Convert.ToString(Console.ReadLine());

                        var loginModel = new LoginModel()
                        {
                            Login = login,
                            Password = password,
                        };

                        usuarioService.Logar(loginModel);

                        Console.WriteLine($"{logado}");

                    }

                    if (opcaoDeslogado == 2)
                    {
                        //VARIAVEIS NESCESSÁRIAS PARA UM CADASTRO                    
                        string login;
                        string password;
                        int nivel;
                        string nome;
                        DateTime dataNascimento;
                        int unidade;

                        //FORMULARIO PARA CADASTRO DE USUARIO
                        Console.WriteLine("Insira os dados do usuario:");
                        Console.WriteLine("\n Login:");
                        login = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\n Password:");
                        password = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\n Nivel:");
                        nivel = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n Nome:");
                        nome = Convert.ToString(Console.ReadLine());
                        Console.WriteLine("\n Data de nascimento:");
                        dataNascimento = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("\n Unidade:");
                        unidade = Convert.ToInt32(Console.ReadLine());

                        var usuario = new Usuario()
                        {
                            Login = login,
                            Password = password,
                            Nivel = nivel,
                            Nome = nome,
                            DataNascimento = dataNascimento,
                            Unidade = unidade,
                        };

                        usuarioService.Cadastrar(usuario);
                        Console.WriteLine("\n Usuario cadastrado com sucesso.");
                    }
                } while (opcaoDeslogado != 0);
            }















        }
    }
}