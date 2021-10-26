using System;
using System.ComponentModel.DataAnnotations;

namespace ativ.Domain.Entities
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nascionalidade { get; set; }
        public DateTime Naturalidade { get; set; }

    }
}
