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
    internal class AtendimentoDetalhadoService
    {

        public List<AtendimentoDetalhadoDto> ListarAtendimentosUsuario(int idUsuarioValidado)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os serviços dentro da api;

            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44378/AtendimentosDetalhados/SearchByIdUser?IdUsuario= {idUsuarioValidado}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<AtendimentoDetalhadoDto>();
                }


                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<AtendimentoDetalhadoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AtendimentoDetalhadoDto>();
            }
        }

        public List<AtendimentoDetalhadoDto> ListarAtendimentosTecnico(int idUsuarioValidado)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //Busca todos os serviços dentro da api;

            try
            {
                //monta a request para a api;
                response = httpClient.GetAsync($"https://localhost:44378/AtendimentosDetalhados/SearchByIdTecnic?IdUsuario= {idUsuarioValidado}").Result;
                response.EnsureSuccessStatusCode();

                var resultado = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine(resultado);
                    return new List<AtendimentoDetalhadoDto>();
                }


                //converte os dados recebidos e retorna eles como objetos do C#;
                var objetoDesserializado = JsonConvert.DeserializeObject<List<AtendimentoDetalhadoDto>>(resultado);

                return objetoDesserializado;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AtendimentoDetalhadoDto>();
            }
        }

        


    }
}
