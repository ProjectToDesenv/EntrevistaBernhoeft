using ativ.Domain.Entities;
using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CloudHttpFunction
{
    public class Function : IHttpFunction
    {
        /// <summary>
        /// Logic for your function goes here.
        /// </summary>
        /// <param name="context">The HTTP context, containing the request and the response.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task HandleAsync(HttpContext context)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Nome = "Bernhoeft";
            pessoa.DataNascimento = System.DateTime.Now;
            await context.Response.WriteAsync("Hello, Functions Framework da BernhoeftFunctions. " + pessoa.Nome + " DataNascimento: " + pessoa.DataNascimento);
        }
    }
}
