using EfCoreSample.Doman;
using EfCoreSample.Infrastructure.Abstraction;
using EfCoreSample.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Infrastructure.Repository
{
    public class EmployeesRepository : IEmployeesRepository<Employee, long>
    {
        private EfCoreSampleDbContext db { get; set; }

        public EmployeesRepository(EfCoreSampleDbContext context)
        {
            db = context;
        }

        public Employee Find(long key)
        {
            return db.Employees.FirstOrDefault(p => p.Id == key);
        }

        public async Task<Employee> FindAsync(long key)
        {
            return await db.Employees.FirstOrDefaultAsync(p => p.Id == key);
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            return await db.Employees.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(long key)
        {

            return await db.Employees.FromSql("Select * from employee, employeeproject " +
                                              "Where Employee.Id = employeeproject.EmployeeId " +
                                              "and employeeproject.ProjectId = {0}", key).ToListAsync<Employee>();
        }



        public async Task<Employee> InsertAsync(Employee item)
        {
            db.Employees.Add(item);
            await db.SaveChangesAsync();
            return await db.Employees.FindAsync(item.Id);
        }

        public bool IsExist(long key)
        {
            return db.Employees.Any(p => p.Id == key);
        }

        public async Task<bool> IsExistAsync(long key)
        {
            return await db.Employees.AnyAsync(p => p.Id == key);
        }


        public Employee Update(Employee item)
        {
            db.Employees.Update(item);
            db.SaveChanges();

            return db.Employees.Find(item.Id);
        }


        public bool Remove(Employee item)
        {
            try
            {
                db.Employees.Remove(item);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Remove(long key)
        {
            Employee project = db.Employees.FirstOrDefault(p => p.Id == key);
            if (project != null)
            {
                db.Employees.Remove(project);
                db.SaveChanges();
                return true;
            }
            return false;

        }



    }
}
