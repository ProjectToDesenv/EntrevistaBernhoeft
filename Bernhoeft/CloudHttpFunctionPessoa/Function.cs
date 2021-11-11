using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudHttpFunctionPessoa
{
    public class Pessoa
    {
        //[Key]
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nascionalidade { get; set; }
        public string Naturalidade { get; set; }
        public string NomeMae { get; set; }       

    }
    public class Function : IHttpFunction
    {
        /// <summary>
        /// Logic for your function goes here.
        /// </summary>
        /// <param name="context">The HTTP context, containing the request and the response.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task HandleAsync(HttpContext context)
        {
            List<Pessoa> ListPessoa = new List<Pessoa>();
            List<Pessoa> PessoasEncontradas = new List<Pessoa>();

            Pessoa pessoa1 = new Pessoa();
            pessoa1.Nome = "Marcelo";
            pessoa1.IdPessoa = 1;


            Pessoa pessoa2 = new Pessoa();
            pessoa2.Nome = "Rafael";
            pessoa2.IdPessoa = 2;
            zzz
            ListPessoa.Add(pessoa1);
            ListPessoa.Add(pessoa2);

            string retorno = context.Request.Query["codigo"];

            if(!string.IsNullOrEmpty(retorno))
            {
                PessoasEncontradas = ListPessoa.Where(x => x.IdPessoa.ToString() == retorno).ToList();
            }
            else
            {
                PessoasEncontradas = ListPessoa;
            }
      

            // string pessoaJson = JsonConvert.SerializeObject(ListPessoa);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(PessoasEncontradas));


        }
    }
}
