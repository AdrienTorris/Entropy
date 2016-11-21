using Entropy.DBTransaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Entropy.DBTransaction.BusinessLogic
{
    public interface IService3
    {
        void Create_ThrowExceptionAfterSecondSaveChanges(Guid key);
        void CreateInBoth(Guid key);

        // PLAN B : not clean
        //void Create(Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction dbt, Guid key);

        void Create_ThrowExceptionAfterSecondSaveChangesWithScope(Guid key);
    }

    public sealed class Service3 : IService3
    {
        private readonly IRepository1 _repo1;
        private readonly IRepository2 _repo2;
        private readonly ITransactionProvider _transactionProvider;

        public Service3(IRepository1 repo1, IRepository2 repo2, ITransactionProvider transactionProvider)
        {
            _repo1 = repo1;
            _repo2 = repo2;
            _transactionProvider = transactionProvider;
        }

        public void Create_ThrowExceptionAfterSecondSaveChanges(Guid key)
        {
            _repo1.Create(key);
            _repo2.Create_ThrowExceptionAfterSaveChanges(key);
        }

        //public void Create_ThrowExceptionAfterSecondSaveChangesWithScope(Guid key)
        //{
        //    using (TransactionScope scope = new TransactionScope())
        //    {
        //        try
        //        {
        //            _repo1.CreateWithNoTransaction(key);
        //            _repo2.Create_ThrowExceptionAfterSaveChangesWithNoTransaction(key);

        //            scope.Complete();
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

        public void Create_ThrowExceptionAfterSecondSaveChangesWithScope(Guid key)
        {
            _transactionProvider.BeginTransaction();

            try
            {
                _repo1.CreateWithNoTransaction(key);
                _repo2.Create_ThrowExceptionAfterSaveChangesWithNoTransaction(key);

                _transactionProvider.CommitTransaction();
            }
            catch (Exception)
            {
                _transactionProvider.RollbackTransaction();
                throw;
            }
            finally
            {
                _transactionProvider.DisposeTransaction();
            }
        }

        public void CreateInBoth(Guid key)
        {
            _transactionProvider.BeginTransaction();

            try
            {
                _repo1.CreateWithNoTransaction(key);
                _repo2.CreateWithNoTransaction(key);

                _transactionProvider.CommitTransaction();
            }
            catch (Exception)
            {
                _transactionProvider.RollbackTransaction();
                throw;
            }
            finally
            {
                _transactionProvider.DisposeTransaction();
            }
        }
    }
}