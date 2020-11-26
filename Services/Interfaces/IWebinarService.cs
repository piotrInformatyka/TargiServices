using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Infrastructure.Command;
using Targi.Infrastructure.Dto;

namespace Targi.Infrastructure.Services.Interfaces
{
    public interface IWebinarService
    {
        Task<Guid> AddWebinarAsync(Guid userId, WebinarForUpdate command);
        Task<WebinarDetailDto> GetWebinarDetailAsync(Guid webinarId);
        Task<IEnumerable<WebinarForListDto>> GetWebinarsAsync();
        Task<bool> UpdateWebinarAsync(Guid webinarId, WebinarForUpdate webinarForUpdate);
        Task<bool> UpdatePhotos(Guid webinarId, string description, string url);
        Task<bool> DeleteWebinar(Guid webinarId);

    }
}
