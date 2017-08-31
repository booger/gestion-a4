using Core.Data.Infrastructure;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IStockRepository : IRepository<Stock>
    {

    }
}
