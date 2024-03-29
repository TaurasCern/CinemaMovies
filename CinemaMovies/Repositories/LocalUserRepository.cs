﻿using CinemaMovies;
using CinemaMovies.Data;
using CinemaMovies.DTO;
using CinemaMovies.Models;
using CinemaMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_mokymai.Repository
{
    public class LocalUserRepository : ILocalUserRepository
    {
        private readonly CinemaContext _db;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public LocalUserRepository(CinemaContext db, IPasswordService passwordService, IJwtService jwtService)
        {
            _db = db;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Should return a flag indicating if a user with a specified username already exists
        /// </summary>
        /// <param name="email">Registration username</param>
        /// <returns>A flag indicating if username already exists</returns>
        public async Task<bool> IsUniqueUserAsync(int username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.Username == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var inputPasswordBytes = Encoding.UTF8.GetBytes(loginRequest.Password);
            var user = await _db.LocalUsers.FirstOrDefaultAsync(x => x.Username.ToLower() == loginRequest.Username.ToLower());

            if (user == null || !_passwordService.VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new LoginResponse
                {
                    Token = "",
                    User = null
                };
            }

            var token = _jwtService.GetJwtToken(user.Username, user.UserId);

            LoginResponse loginResponse = new()
            {
                Token = token,
                User = user
            };

            loginResponse.LocalUsers.PasswordHash = null;

            return loginResponse;

            //// To generate JWT token
            //// 1. To generate a JWT token we need a secret.
            //// 1.1 Key will be used to encrypt our message
            //// 1.2 It will be used to verify/validate token
            //// 1.3 Secret HAS to be known only to application
            //// 1.4 Secret is used to sign and verify tokens

            //// JWT structure: header.payload.signature
            //// install-package Microsoft.AspNetCore.Authentication.JwtBearer -Version 6.0.11
            //var tokenHandler = new JwtSecurityTokenHandler();

            //// For token handler we need:
            //// 1. A key(Which will be in bytes)
            //var key = Encoding.ASCII.GetBytes(_secretKey);

            //// 2. Token descriptor
            //var tokenDescriptor = new SecurityTokenDescriptor()
            //{
            //    // Claim is required to identify WHO is the client/entity/person that is trying to use our application
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            //        SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //LoginResponse loginResponse = new()
            //{
            //    Token = tokenHandler.WriteToken(token),
            //    User = user
            //};

            //loginResponse.User.Password = "";

            //return loginResponse;
        }

        // Add RegistrationResponse (Should not include password)
        // Add adapter classes to map to wanted classes
        public async Task<LocalUser> RegisterAsync(RegistrationRequest registrationRequest)
        {
            _passwordService.CreatePasswordHash(registrationRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            LocalUser user = new()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Username = registrationRequest.Username,
            };

            _db.LocalUsers.Add(user);
            await  _db.SaveChangesAsync();
            user.PasswordHash = null;
            return user;
        }
    }
}
