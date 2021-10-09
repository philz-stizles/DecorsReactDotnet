using Decors.Domain.Entities;
using System.Threading.Tasks;

namespace Decors.Application.Contracts.Repositories
{
    public interface IAuditRepository
    {
        Task<Audit> AddAsync(Audit entity);
    }
}
