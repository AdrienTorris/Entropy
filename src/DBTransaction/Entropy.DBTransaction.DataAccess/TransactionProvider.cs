using Entropy.DBTransaction.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.DBTransaction.DataAccess
{
    public interface ITransactionProvider
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }

    public class TransactionProvider : BaseRepository, ITransactionProvider
    {
        public TransactionProvider(ApplicationDatabaseContext dbcontext)
            : base(dbcontext)
        { }

        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public void DisposeTransaction()
        {
            _dbContext.Database.CurrentTransaction.Dispose();
        }
    }
}