using Core.Data.Infrastructure;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface IMarcaRepository : IRepository<Marca>
    {

    }
}
