using EfCoreSample.Doman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSample.Services
{
    public interface IService
    {
        Task<Project> Get(long id);
    }
}
