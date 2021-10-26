using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ativ.Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; }
        private IDbContextTransaction _transaction;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }

        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }
    }
}
