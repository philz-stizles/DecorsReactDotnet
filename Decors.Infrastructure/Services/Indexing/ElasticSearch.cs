
using Decors.Application.Contracts.Services;
using Decors.Domain.Entities;
using System.Threading.Tasks;

namespace Decors.Infrastructure.Services.Indexing
{
    public class ElasticSearch<T> : IElasticSearch<T> where T : EntityBase
    {
        public Task Index()
        {
            throw new System.NotImplementedException();
        }

        public Task IndexAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task IndexAsync(T entity, int from, int size)
        {
            throw new System.NotImplementedException();
        }
    }
}
