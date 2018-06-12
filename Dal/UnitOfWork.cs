using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prana.Data.Dal
{
    public class UnitOfWork : IDisposable
    {
        //Our database context
        private PranaEntities dbContext = new PranaEntities();

        //Private members corresponding to each concrete repository
        private BaseRepository<User> userRepository;

        //Accessors for each private repository, creates repository if null
        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new BaseRepository<User>(dbContext);
                }
                return userRepository;
            }

        }

        //Method to save all changes to repositories
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        //IDisposible implementation
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
