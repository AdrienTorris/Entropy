using Entropy.DBTransaction.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropy.DBTransaction.BusinessLogic
{
    public interface IService1
    {
        void Create(Guid key);
        Task<int?> CreateAsync(Guid key);
        void Create_ThrowExceptionAfterSaveChanges(Guid key);
    }

    public sealed class Service1 : IService1
    {
        private readonly IRepository1 _repository;

        public Service1(IRepository1 repository)
        {
            _repository = repository;
        }

        public void Create(Guid key)
        {
            _repository.Create(key);
        }

        public async Task<int?> CreateAsync(Guid key)
        {
            return await _repository.CreateAsync(key);
        }

        public void Create_ThrowExceptionAfterSaveChanges(Guid key)
        {
            _repository.Create_ThrowExceptionAfterSaveChanges(key);
        }
    }
}