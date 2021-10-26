using Microsoft.EntityFrameworkCore;

namespace Ativ.Infra.Data.Transactions
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        void BeginTransaction();
        void Commit();
    }
}
