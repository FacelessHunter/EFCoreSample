using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreSample.Services
{
    public interface IEmployeesService : IBaseService
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(long id);
        Task<IEnumerable<Employee>> GetEmployees(long key);
        Task<Employee> Create(Employee item);
        Employee Update(Employee item);
        bool Remove(Employee item);
        bool Remove(long id);
    }
}
