using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChamadosTiApi.Dtos;
using ChamadosTiApi.Controllers;
using ChamadosTiApi.Repositories;
using ChamadosTiApi.ViewModels;

namespace ChamadosTiApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Nivel { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade
        {
            get
            {
                return DateTime.Now.Year - DataNascimento.Year;
            }
        }
        public int Unidade { get; set; }

        public Usuario() { }

        public Usuario(int id, string login, string password, int nivel, string nome, DateTime dataNascimento, int unidade)
        {
            Id = id;
            Login = login;
            Password = password;
            Nivel = nivel;
            Nome = nome;
            DataNascimento = dataNascimento;
            Unidade = unidade;
        }
    }
}
