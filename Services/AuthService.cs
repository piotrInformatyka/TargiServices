using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Targi.Core.Domain;
using Targi.Core.Repositories;
using Targi.Infrastructure.Dto;
using Targi.Infrastructure.Helpers;
using Targi.Infrastructure.Extensions;
using System.Linq;

namespace Targi.Infrastructure.Services
{
    public class AuthService :  IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;
        public AuthService(IUserRepository userRepo, IJwtHandler jwtHandler)
        {
            _userRepository = userRepo;
            _jwtHandler = jwtHandler;
        }

        public async Task<TokenDto> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null || !VerifyPasswordHash(password, user.Password, user.PasswordSalt))
            {
                throw new Exception("Invalid credentials");
            }
            string name;
            string logoUrl;
            if (user.Role == "company")
            {
                name = user.CompanyProfile.CompanyName;
                if (user.CompanyProfile.Photos.Count != 0)
                    logoUrl = user.CompanyProfile.Photos.SingleOrDefault(x => x.Description == "logo").Url;
                else
                    logoUrl = null;
            }  
            else 
            {
                name = user.ModeratorProfile.ContactPerson;
                logoUrl = null;
            }                
            var jwt = _jwtHandler.CreateTokem(user.Id, user.Role, name);
            return new TokenDto
            {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role,
                LogoUrl = logoUrl,
                IsCompany = user.IsCompany
            };
        }
        public async Task RegisterCompanyAsync(Guid userId, string email, string companyName, string contactPerson, string phoneNumber)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception("User with this email already exist");
            }
            user = User.CreateUserForCompany(userId, companyName, email, phoneNumber, contactPerson);
            await _userRepository.AddAsync(user);
        }
        public async Task AcceptCompanyAsync(string email, string password, string dayOfParticipation, string companyStatus)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            SetPassword(user, password);
            user.AcceptCompany(dayOfParticipation, companyStatus);
            await _userRepository.SaveAll();
        }
        public async Task<bool> ChangePassword(string email, string password)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            SetPassword(user, password);
             return await _userRepository.SaveAll();
        }
        public async Task<bool> UpdateUserAsync(Guid userId, string dayOfParticipation, string companyStatus, 
            string phoneNumber, string contactPerson, int maxJobOffers, string companyName)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            user.UpdateUser(dayOfParticipation, companyStatus, phoneNumber, contactPerson, maxJobOffers, companyName);
            return await _userRepository.SaveAll();
        }
        public async Task<bool> DeactivateUserAsync(Guid userId) 
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            user.DeactivateUser();
            return await _userRepository.SaveAll();
        }
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            if (!user.IsActive && !user.IsCompany)
            {
                _userRepository.Delete(user);
                return (await _userRepository.SaveAll());
            }
            else
                throw new Exception("You can not delete active user or company");
        }
        private void SetPassword(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computtedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computtedHash.Length; i++)
                {
                    if(computtedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}