using EfCoreSample.Doman;
using EfCoreSample.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreSample.Services
{
    public class EmployeesService : IEmployeesService
    {
        IEmployeesRepository<Employee, long> employeesRepository { get; set; }
        public EmployeesService(IEmployeesRepository<Employee, long> employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await employeesRepository.GetAllAsync();
        }

        public async Task<Employee> Get(long key)
        {
            var project = await employeesRepository.FindAsync(key);
            if (project != null)
                return await employeesRepository.FindAsync(key);
            return null;
        }

        public async Task<Employee> Create(Employee item)
        {
            if (!employeesRepository.IsExist(item.Id))
                return await employeesRepository.InsertAsync(item);
            return null;
        }

        public Employee Update(Employee item)
        {
            if (employeesRepository.IsExist(item.Id))
                return employeesRepository.Update(item);
            else return null;
        }


        public bool Remove(Employee item)
        {

            if (!employeesRepository.IsExist(item.Id))
            {
                return employeesRepository.Remove(item);
            }
            else return false;
        }

        public bool Remove(long key)
        {
            var project = employeesRepository.Find(key);
            if (project != null)
                return employeesRepository.Remove(key);
            else return false;
        }

    }
}
