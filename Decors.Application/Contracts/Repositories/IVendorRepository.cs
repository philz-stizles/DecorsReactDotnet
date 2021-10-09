using Decors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Repositories
{
    public interface IVendorRepository : IAsyncRepository<Vendor>
    {
        Task<Vendor> GetByIdAsync(int id, string includeString = null, bool disableTracking = true);
        Task<Vendor> GetByIdAsync(int id, List<Expression<Func<Vendor, object>>> includes = null, 
            bool disableTracking = true);
    }
}
