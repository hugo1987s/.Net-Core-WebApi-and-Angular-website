
using Northwind.Repositories;
using Northwind.UnitOfWork;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set;}

        public IUserRepository User { get; private set; }
    }
}
