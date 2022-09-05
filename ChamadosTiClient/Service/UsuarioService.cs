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
    public class UsuarioService
    {
        public void Cadastrar(Usuario usuario)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;

            //var viewModel = new
            //{
            //    usuario = usuario,
            //};

            try
            {
                response = httpClient.CreateAsJsonAsync($"https://localhost:44378/usuarios/save", usuario);

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


        public bool Logar(LoginModel loginModel)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response;
            bool verificado = false;

            //var viewModel = new
            //{
            //    usuario = usuario,
            //};

            try
            {
                response = httpClient.CreateAsJsonAsync($"https://localhost:44378/usuarios/logar", loginModel);

                verificado = (response.StatusCode == System.Net.HttpStatusCode.NotFound) ? true : false;
                return verificado;

                //if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                //{
                //    Console.WriteLine(response);
                //}


            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                verificado = false;
            }
            return verificado;
        }



        // LOGAR DE FORMA ASYNC
        //public bool Logar(LoginModel loginModel)
        //{
        //    bool usuarioExiste = false;
        //    HttpClient httpClient = new HttpClient();
        //    HttpResponseMessage response;

        //    //var viewModel = new
        //    //{
        //    //    usuario = usuario,
        //    //};

        //    try
        //    {
        //        response = httpClient.PostAsync($"https://localhost:44323/usuarios/logar", new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();

        //        var res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        //        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        {
        //            Console.WriteLine(response);
        //            usuarioExiste = true;
        //        }
        //        return usuarioExiste;

        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return usuarioExiste;
        //    }
        //}
    }
}
