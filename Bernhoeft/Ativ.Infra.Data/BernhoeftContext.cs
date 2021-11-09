using ativ.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ativ.Infra.Data
{
    public class BernhoeftContext : DbContext
    {
        public BernhoeftContext(DbContextOptions<BernhoeftContext> options)
            : base(options)
        { }

        public DbSet<Pessoa> Pessoa { get; set; }


      

    }
}
