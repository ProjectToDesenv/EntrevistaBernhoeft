using ativ.Domain.Entities;
using Ativ.Infra.Data.Repository;
using Ativ.Infra.Data.Transactions;

namespace ApiBernhoeft.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
    }
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        private IUnitOfWork _unitOfWork;

        public PessoaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
