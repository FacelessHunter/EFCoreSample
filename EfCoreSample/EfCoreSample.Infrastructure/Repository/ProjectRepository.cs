﻿using EfCoreSample.Doman;
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
            return await db.Projects.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await db.Projects.ToListAsync();
        }

        public async Task<Project> InsertAsync(Project item)
        {
            db.Projects.Add(item);
            await db.SaveChangesAsync();
            return await db.Projects.FindAsync(item.Id);
        }

        public async Task<bool> IsExistAsync(long key)
        {
            return await db.Projects.AnyAsync(p => p.Id == key);
        }
        public async void UpdateRange(IEnumerable<Project> items)
        {
            db.Projects.UpdateRange(items);
            await db.SaveChangesAsync();
        }
        public Project Update(Project item)
        {
            db.Projects.Update(item);
            db.SaveChanges();
            return db.Projects.Find(item.Id);
        }
        public bool Remove(Project item)
        {
            try
            {
                db.Projects.Remove(item);
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
            Project project = db.Projects.FirstOrDefault(p => p.Id == key);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                return true;
            }
            return false;

        }



    }
}
