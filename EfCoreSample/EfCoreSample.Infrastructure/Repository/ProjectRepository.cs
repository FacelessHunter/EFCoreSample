using EfCoreSample.Doman;
using EfCoreSample.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCoreSample.Persistance;
using Microsoft.EntityFrameworkCore;
using EfCoreSample.Infrastructure;
namespace EfCoreSample.Infrastructure
{
    public class ProjectRepository : IRepository<Project, long>
    {
        private EfCoreSampleDbContext db { get; set;}
        public ProjectRepository(EfCoreSampleDbContext context)
        {
            db = context;
        }

        public async Task<Project> FindAsync(long key)
        {
            
            return await db.Projects.FirstOrDefaultAsync(p => p.Id == key);
        }

        public async Task<IEnumerable<Project>> GetAsync(Expression<Func<Project, bool>> expression)
        {

            return null; //await db.Projects.<IEnumerable<Project>>(expression);
        }

        public Task<Project> InsertAsync(Project item)
        {
            return null;
        }
        public Task<bool> IsExistAsync(long key)
        {
            return null;
        }
        public void UpdateRange(IEnumerable<Project> items)
        {
            
        }
        public Project Update(Project item)
        {
            return null;
        }
        public bool Remove(Project item)
        {
            return false;
        }
        public bool Remove(long key)
        {
            return false;
        }



    }
}
