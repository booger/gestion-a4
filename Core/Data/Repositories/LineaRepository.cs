using Core.Data.Infrastructure;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class LineaRepository : RepositoryBase<Linea>, ILineaRepository
    {
        public LineaRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface ILineaRepository : IRepository<Linea>
    {

    }
}
