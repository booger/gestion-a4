using Core.Data.Infrastructure;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class DepositoRepository : RepositoryBase<Deposito>, IDepositoRepository
    {
        public DepositoRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IDepositoRepository : IRepository<Deposito>
    {

    }
}
