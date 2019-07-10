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

        /*public IEnumerable<Employee> GetEmployees(long key)
        {
            List<Employee> employees = new List<Employee>();
            var projects = db.Projects.Where(p => p.Id == key).Include(p => p.EmployeeProjects).ThenInclude(p => p.Employee).Single();
            foreach (var x in projects.EmployeeProjects)
                employees.Add(x.Employee);
            return employees;
           /* var project = db.Projects.Single(p => p.Id == key);
            var employeeProjects = db.Entry(project).Collection(e => e.EmployeeProjects).EntityEntry.Entity.EmployeeProjects;
            employeeProjects.
            var employees = db.Entry(employeeProjects).Collection(e => e. );
            
        }*/

        /* public async Task<IEnumerable<Employee>> GetMembersAsync(long key)
         {
            /* List<Employee> employees = new List<Employee>();
             var project = await db.Projects
                 .Where(p => p.Id == key)
                 .Include(p => p.EmployeeProjects)
                 .ThenInclude(e => e.Employee)
                 .FirstOrDefaultAsync();

             var employeeProjects = project.EmployeeProjects.Where(p => p.ProjectId == key).ToList();

             foreach (var x in employeeProjects)
                 employees.Add(x.Employee);
             //employees[1].EmployeeProjects
             //var empl = employees.

             /*var project = db.Projects
                 .Single(p => p.Id == key);
             //var temp = project.EmployeeProjects.Single();

             db.Entry(project)
                 .Collection(p => p.EmployeeProjects)
                 .Query()
                 .Load();
             var sad = project.EmployeeProjects;
             sad.
            // return await employees
             //return employees;
         }*/

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
