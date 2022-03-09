using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationContext _applicationContext;
        private IUserRepository _user;

        public RepositoryWrapper(ApplicationContext applicationContext)
        {
            this._applicationContext = applicationContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                    _user = new UserRepository(_applicationContext);

                return _user;
            }
        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
