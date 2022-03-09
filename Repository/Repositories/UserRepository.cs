using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }

        public void Create(User user)
        {
            base.Create(user);
        }

        public void Delete(User user)
        {
            base.Delete(user);
        }

        public async Task<IEnumerable<User>> FindAllAsync()
        {
            return await base.FindAll().ToListAsync();
        }

        public async Task<User> FIndAsyncByCredential(string email, string password)
        {
            return await base.FindByCondition(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefaultAsync();
        }

        public async Task<User> FindAsyncById(string id)
        {
            return await base.FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public void Update(User user)
        {
            base.Update(user);
        }
    }
}
