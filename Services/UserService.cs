using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProiectASP.Entities;
using ProiectASP.Entities.Constants;
using ProiectASP.Entities.DTOs;
using ProiectASP.Repositories.SessionTokenRepository;
using ProiectASP.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProiectASP.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ISessionTokenRepository _repository;
        private readonly IUserRepository _repository2;

        public UserService(
            UserManager<User> userManager,
            ISessionTokenRepository repository,
            IUserRepository repository2)
        {
            _userManager = userManager;
            _repository = repository;
            _repository2 = repository2;
        }


        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Nume;
            registerUser.Prenume = dto.Prenume;
            registerUser.Telefon = dto.Telefon;
            registerUser.Rol = dto.Rol;


            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {
                if (registerUser.Rol == "Client")
                {
                    await _userManager.AddToRoleAsync(registerUser, UserRoleType.Client);
                }

                if (registerUser.Rol == "Executant")
                {
                    await _userManager.AddToRoleAsync(registerUser, UserRoleType.Executant);
                }

                if (registerUser.Rol == "Proiectant")
                {
                    await _userManager.AddToRoleAsync(registerUser, UserRoleType.Proiectant);
                }

                if (registerUser.Rol == "Admin")
                {
                    await _userManager.AddToRoleAsync(registerUser, UserRoleType.Admin);
                }
                return true;
            }

            return false;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repository2.GetByIdWithRoles(user.Id);

                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                var newJti = Guid.NewGuid().ToString();

                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismysecretkey"));

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                _repository.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository.SaveAsync();

                return tokenHandler.WriteToken(token);
            }

            return "";
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string jti)
        {
            var subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Nume + " " + user.Prenume),
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, jti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "test",
                Subject = subject,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha384)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
