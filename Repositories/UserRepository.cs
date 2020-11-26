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
    public class UserRepository : GenericRepository, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetAsync(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;
            if (user.Role == "company")
                user.CompanyProfile = await _context.CompanyProfiles.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserId == user.Id);
            else
                user.ModeratorProfile = await _context.ModeratorProfiles.SingleOrDefaultAsync(x => x.UserId == user.Id);
            return user;
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return null;
            if (user.Role == "company")
                user.CompanyProfile = await _context.CompanyProfiles.Include(b=>b.BenefitCards).Include(b=>b.Socials)
                    .Include(b=>b.JobOffers).SingleOrDefaultAsync(x => x.UserId == user.Id);
            else
                user.ModeratorProfile = await _context.ModeratorProfiles.SingleOrDefaultAsync(x => x.UserId == user.Id);
            return user;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
                return null;
            foreach (User user in users)
            {
                if(user.Role == "company")
                    user.CompanyProfile = await _context.CompanyProfiles.SingleOrDefaultAsync(x => x.UserId == user.Id);
                else
                    user.ModeratorProfile = await _context.ModeratorProfiles.SingleOrDefaultAsync(x => x.UserId == user.Id);
            }
            return users;
        }
    }
}
