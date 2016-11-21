using Entropy.DBTransaction.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Entropy.DBTransaction.DataAccess
{
    public interface IRepository1
    {
        void Create(Guid key);
        Task<int?> CreateAsync(Guid key);
        void Create_ThrowExceptionAfterSaveChanges(Guid key);
        void Create(Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbt, Guid key);
        void CreateWithNoTransaction(Guid key);
    }

    public sealed class Repository1 : BaseRepository, IRepository1
    {
        public Repository1(ApplicationDatabaseContext dbcontext)
            : base(dbcontext)
        { }


        public void Create(Guid key)
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.TransactionLog1.Add(new TransactionLog1 { Key = key });
                    _dbContext.SaveChanges();

                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void CreateWithNoTransaction(Guid key)
        {
            try
            {
                _dbContext.TransactionLog1.Add(new TransactionLog1 { Key = key });
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Create(Guid key, bool commit = true)
        {
            using (_dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.TransactionLog1.Add(new TransactionLog1 { Key = key });
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
                    TransactionLog1 tl = new TransactionLog1 { Key = key };
                    _dbContext.TransactionLog1.Add(tl);
                    _dbContext.SaveChangesAsync();

                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs

                    ret = tl.Id;

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

                    _dbContext.TransactionLog1.Add(new TransactionLog1 { Key = key });
                    _dbContext.SaveChanges();


                    _dbContext.Database.CommitTransaction(); // If not, nothing occurs

                    throw new Exception("Exception manualy throwed after SaveChanges(), key " + key.ToString());
                }
                catch (Exception)
                {
                    _dbContext.Database.RollbackTransaction();

                    throw;
                }

            }
        }

        public void Create(Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbt, Guid key)
        {
            try
            {
                _dbContext.TransactionLog1.Add(new TransactionLog1 { Key = key });
                _dbContext.SaveChanges();

                _dbContext.Database.CommitTransaction(); // If not, nothing occurs
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}