using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Infrastructure.Command.JobOffers;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Helpers;

namespace Targi.Infrastructure.Services.Interfaces
{
    public interface IJobOfferService
    {
        Task<Guid> AddJobOfferAsync(Guid userId, JobOfferForUpdate command);
        Task<bool> UpdateJobOfferAsync(Guid userId, Guid jobId, JobOfferForUpdate command);
        Task<IEnumerable<JobOfferForListDto>> GetJobOffersForCompany(Guid Id);
        Task<JobOfferDetailDto> GetDetailJobOfferAsync(Guid jobId);
        Task<bool>UpdatePhotos(Guid userId, Guid jobId, string Description, string Url);
        Task<IEnumerable<JobOfferForListHomeDto>>GetJobOffers(JobOfferParams jobOfferParams);
        Task<bool> DeleteJobOfferAsync(Guid userId, Guid jobId);
        Task<bool> SetIsPromotedAsync(Guid jobId);
    }
}
