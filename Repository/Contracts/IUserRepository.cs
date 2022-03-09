using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAllAsync();
        Task<User> FindAsyncById(string id);
        Task<User> FIndAsyncByCredential(string email, string password);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
