using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;

namespace Targi.Infrastructure.Extensions
{
   public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            return user;
        }
        public static async Task<User> GetCompanyOrFailAsync(this ICompanyRepository repository, Guid userId)
        {
            var user = await repository.GetCompanyById(userId);
            if (user == null)
            {
                throw new Exception("Company does not exist");
            }
            return user;
        }
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception("User does not exist");
            }
            return user;
        }
    }
}
