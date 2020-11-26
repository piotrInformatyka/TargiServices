using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Infrastructure.Command.Companies;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Dto.Companies;

namespace Targi.Infrastructure.Services
{
    public interface ICompanyService
    {
        Task<CompanyProfileDto> GetCompanyAsync(Guid userId);
        Task<IEnumerable<CompanyProfileForListDto>> GetCompaniesForList();
        Task<IEnumerable<CompanyProfileForListModeratorDto>> GetAllForModerator();
        Task<IEnumerable<CompanyForAcceptDto>> GetNotAcceptedCompaniesAsync();
        Task<IEnumerable<CompanyForAcceptDto>> GetDeactivatedCompaniesAsync();
        Task<bool> UpdateCompany(Guid userId, CompanyForUpdate companyForUpdate);
        Task UpdatePhotos(Guid userId, Guid photoId, string Description, string Url);
    }
}
