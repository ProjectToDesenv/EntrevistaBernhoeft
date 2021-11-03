using ApiBernhoeft.Repository;
using ativ.Domain.Entities;
using Ativ.Infra.Data.Transactions;
using Google.Cloud.Functions.Framework;
using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CloudHttpFunction
{
    public class Function : IHttpFunction
    {

        private IPessoaRepository _pessoaRepository;
        private IUnitOfWork _iUnitOfWork;

        public Function(IPessoaRepository pessoaRepository, IUnitOfWork iUnitOfWork)
        {
            _pessoaRepository = pessoaRepository;
            _iUnitOfWork = iUnitOfWork;
        }

        public class Startup : FunctionsStartup
        {
            // Virtual methods in the base class are overridden
            // here to perform customization.
        }

        //ICloudEventFunction
        /*
         Uma função acionada por HTTP, que você invoca de solicitações HTTP padrão.
         Uma função direcionada a eventos, que você usa para processar eventos da infraestrutura do Cloud, 
         como mensagens em um tópico do Cloud Pub/Sub ou alterações em um bucket do Cloud Storage.
         */
        /// <summary>
        /// Logic for your function goes here.
        /// </summary>
        /// <param name="context">The HTTP context, containing the request and the response.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// [FunctionsStartup(typeof(Startup))]
        public async Task HandleAsync(HttpContext context)
        {
            Pessoa pessoa = new Pessoa();

            pessoa.Nome = "Bernhoeft";
            pessoa.DataNascimento = System.DateTime.Now;

            _iUnitOfWork.BeginTransaction();
            _pessoaRepository.Add(pessoa);
            _iUnitOfWork.Commit();
            await context.Response.WriteAsync("Hello, Functions Framework da BernhoeftFunctions. " + pessoa.Nome + " DataNascimento: " + pessoa.DataNascimento);
        }
    }
}
