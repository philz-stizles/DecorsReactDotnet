using Decors.Application.Contracts.Repositories;
using Decors.Domain.Entities;
using Decors.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Persistence.Repositories
{
    public class VendorRepository: RepositoryBase<Vendor>, IVendorRepository
    {
        public VendorRepository(DataDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Vendor> GetByIdAsync(int id, string includeString = null, bool disableTracking = true)
        {
            IQueryable<Vendor> query = _dbContext.Set<Vendor>();
            if (disableTracking) query = query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            var target = await query.SingleOrDefaultAsync(v => v.Id == id);

            return target;
        }

        public async Task<Vendor> GetByIdAsync(int id, List<Expression<Func<Vendor, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<Vendor> query = _dbContext.Set<Vendor>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            query = query.Where(v => v.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
