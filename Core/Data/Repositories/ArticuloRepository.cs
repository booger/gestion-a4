using Core.Data.Infrastructure;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class ArticuloRepository : RepositoryBase<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IArticuloRepository : IRepository<Articulo>
    {

    }
}
