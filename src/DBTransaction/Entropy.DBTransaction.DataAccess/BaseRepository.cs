using Entropy.DBTransaction.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.DBTransaction.DataAccess
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDatabaseContext _dbContext;

        public BaseRepository(ApplicationDatabaseContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        
    }
}
