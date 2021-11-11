using System;
using System.ComponentModel.DataAnnotations;

namespace Google.Cloud.Functions.Entities
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nascionalidade { get; set; }
        public string Naturalidade { get; set; }
        public string NomeMae { get; set; }

    }
}
