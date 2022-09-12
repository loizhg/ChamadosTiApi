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
    public class AtendimentoService
    {
        public void Cadastrar(Atendimento atendimento)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //var viewModel = new
            //{
            //    usuario = usuario,
            //};

            try
            {
                response = httpClient.CreateAsJsonAsync($"https://localhost:44378/atendimentos/save", atendimento);

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

        public void FinalizarAtendimento(int atendimentoEscolhido)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            try
            {
                response = httpClient.UpdateAsJsonAsync($"https://localhost:44378/atendimentos/Finish?Id= {atendimentoEscolhido}", atendimentoEscolhido).Result;

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
