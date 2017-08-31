using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        EntitiesContext dbContext;

        public DbFactory( EntitiesContext contexto)
        {
            this.dbContext = contexto;
        }

        public EntitiesContext Init()
        {
            return dbContext;
            //return dbContext ?? (dbContext = new EntitiesContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
