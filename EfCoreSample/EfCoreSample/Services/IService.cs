using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Services
{
    public interface IService
    {
        Task<IEnumerable<Project>> Get();
        Task<Project> Get(long id);
        //Task<IEnumerable<Project>> GetMembersAsync(long key);
        Task<bool> Create(Project item);
        Project Update(Project item);
        void UpdateRange(IEnumerable<Project> item);
        bool Remove(Project item);
        bool Remove(long id);
    }
}
