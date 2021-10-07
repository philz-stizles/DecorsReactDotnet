using Decors.Domain.Entities;
using System.Collections.Generic;

namespace Decors.Application.Contracts.Services
{
    public interface IJwtService
    {
        public string CreateToken(User user, IList<string> roles);
    }
}
