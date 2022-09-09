using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

using ChamadosTiClient.Dtos;
using ChamadosTiClient.Models;
using ChamadosTiClient.Extensions;
using System.Threading.Tasks;

namespace ChamadosTiClient.Service
{
    public class ChamadoService
    {

        public void Cadastrar(Chamado chamado)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //var viewModel = new
            //{
            //    usuario = usuario,
            //};

            try
            {
                response = httpClient.CreateAsJsonAsync($"https://localhost:44378/chamados/save", chamado);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(response);
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public List<ChamadoDto> ListarChamados(int idUsuarioValidado)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os serviços dentro da api;


            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44378/chamados/searchbyid?IdUsuario= {idUsuarioValidado}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ChamadoDto>();
                }


                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ChamadoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ChamadoDto>();
            }
        }

        public List<ChamadoDto> ListarChamadosDisponiveis()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os serviços dentro da api;


            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44378/chamados/SearchAvalibles").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<ChamadoDto>();
                }


                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<ChamadoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ChamadoDto>();
            }
        }


        public void Atualizar(int chamadoEscolhido)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;            

            try
            {                
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44378/chamados/Update?Id= {chamadoEscolhido}", chamadoEscolhido).Result;               

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(response);
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




    }
}
