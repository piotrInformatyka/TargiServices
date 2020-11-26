using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;
using Targi.Infrastructure.Data;

namespace Targi.Infrastructure.Repositories
{
    public class CompanyRepository : UserRepository, ICompanyRepository
    {
        private readonly DataContext _context;
        public CompanyRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetCompaniesForList()
        {
            var companies = await _context.Users.Where(x => x.IsCompany).Where(x => x.IsActive)
                .Include(p => p.CompanyProfile).Include(p => p.CompanyProfile.Photos).ToListAsync();
            return companies;
        }
        public async Task<IEnumerable<User>> GetAllForModerator()
        {
            var companies = await _context.Users.Where(x => x.IsActive).Include(p => p.CompanyProfile).ThenInclude(x => x.Photos).ToListAsync();
            return companies;
        }
        public async Task<User> GetCompanyById(Guid userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (user == null || user.Role != "company")
                return null;
            if (user.Role == "company")
            {
                user.CompanyProfile = await _context.CompanyProfiles.Include(b => b.BenefitCards).Include(b => b.Socials)
                    .Include(b => b.Photos).Include(b => b.Webinars).SingleOrDefaultAsync(x => x.UserId == user.Id);
                user.CompanyProfile.JobOffers = await _context.JobOffers.Include(b => b.Photos)
                    .Where(x => x.CompanyProfileId == user.CompanyProfile.Id).ToListAsync();
            }
            return user;
        }
    }
}
