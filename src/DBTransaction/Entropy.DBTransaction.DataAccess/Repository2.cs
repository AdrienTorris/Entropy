using Entropy.DBTransaction.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.DBTransaction.DataAccess
{
    public interface IRepository2
    {
        void Create(Guid key);
        Task<int?> CreateAsync(Guid key);
        void Create_ThrowExceptionAfterSaveChanges(Guid key);
        void Create(Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbt, Guid key);
        void Create_ThrowExceptionAfterSaveChangesWithNoTransaction(Guid key);
        void CreateWithNoTransaction(Guid key);
    }

    public sealed class Repository2 : BaseRepository, IRepository2
    {
        public Repository2(ApplicationDatabaseContext dbcontext)
            : base(dbcontext)
        { }

        public void Create(Guid key)
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.TransactionLog2.Add(new TransactionLog2 { Key = key });
                    _dbContext.SaveChanges();

                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<int?> CreateAsync(Guid key)
        {
            int? ret = 0;

            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    TransactionLog2 tl = new TransactionLog2 { Key = key };
                    _dbContext.TransactionLog2.Add(tl);
                    _dbContext.SaveChangesAsync();

                    ret = tl.Id;

                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return ret;
        }

        public void Create_ThrowExceptionAfterSaveChanges(Guid key)
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.TransactionLog2.Add(new TransactionLog2 { Key = key });
                    _dbContext.SaveChanges();

                    throw new Exception("Exception manualy throwed after SaveChanges(), key " + key.ToString());

                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public void Create(Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbt, Guid key)
        {
            try
            {
                _dbContext.TransactionLog2.Add(new TransactionLog2 { Key = key });
                _dbContext.SaveChanges();

                _dbContext.Database.CommitTransaction(); // If not, nothing occurs
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create_ThrowExceptionAfterSaveChangesWithNoTransaction(Guid key)
        {
            try
            {
                _dbContext.TransactionLog2.Add(new TransactionLog2 { Key = key });
                _dbContext.SaveChanges();

                throw new Exception("Exception manualy throwed after SaveChanges(), key " + key.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateWithNoTransaction(Guid key)
        {
            try
            {
                _dbContext.TransactionLog2.Add(new TransactionLog2 { Key = key });
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}