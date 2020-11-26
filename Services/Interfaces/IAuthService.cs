using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Infrastructure.Dto;

namespace Targi.Infrastructure.Services
{
    public interface IAuthService
    {
        Task RegisterCompanyAsync(Guid userId, string email, string companyName, string contactPerson, string phoneNumber );
        Task<TokenDto> LoginAsync(string email, string password);
        Task AcceptCompanyAsync(string email, string password, string dayOfParticipatio, string companyStatus);
        Task<bool> ChangePassword(string email, string password);
        Task<bool> UpdateUserAsync(Guid userId, string dayOfParticipation, string companyStatus,
            string phoneNumber, string contactPerson, int maxJobOffers, string companyName);
        Task<bool> DeactivateUserAsync(Guid userId);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}