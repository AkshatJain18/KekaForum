using AutoMapper;
using KekaForum.Models;
using KekaForum.Models.Core;
using KekaForum.Services.Interfaces;
using KekaForum.Services.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KekaForum.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Models.Data.User> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly SignInManager<Models.Data.User> SignInManager;
        private readonly IDepartmentService DepartmentService;
        private readonly IMapper Mapper;
        private readonly ILocationService LocationService;
        public AuthService(UserManager<Models.Data.User> userManager,SignInManager<Models.Data.User> signInManager, RoleManager<IdentityRole> roleManager, IDepartmentService departmentService,ILocationService locationService,IMapper mapper)
        {
            this.UserManager = userManager;
            this.RoleManager = roleManager;
            this.SignInManager = signInManager;
            this.DepartmentService = departmentService;
            this.Mapper = mapper;
            this.LocationService = locationService;
        }

        public async Task<KekaForum.Models.Core.User> Login(Login loginModel)
        {
            var user = await this.UserManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                return null;
            }

            var result = await this.SignInManager.PasswordSignInAsync(user.UserName, loginModel.Password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var tokenJson = this.GenerateToken(user);

            Department department= await this.DepartmentService.GetDepartmentById(user.DepartmentId);
            Location location = await this.LocationService.GetLocationById(user.LocationId);

            return new KekaForum.Models.Core.User
            {
                AccessToken = tokenJson,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Designation = user.Designation,
                Department = department.Name,
                Location = location.City
            };
        }

        public async Task<KekaForum.Models.Core.User> Register(Register registerModel)
        {
            var user = new Models.Data.User
            {
                UserName = (registerModel.Email).Split('@')[0],
                Email = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                PhoneNumber=registerModel.PhoneNumber,
                Designation=registerModel.Designation,
                DepartmentId = registerModel.DepartmentId,
                LocationId = registerModel.LocationId,
                ProfilePicUrl=registerModel.ProfilePicUrl
            };

            var result = await this.UserManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                return null;
            }

            var tokenJson = this.GenerateToken(user);

            Department department = await this.DepartmentService.GetDepartmentById(user.DepartmentId);
            Location location = await this.LocationService.GetLocationById(user.LocationId);

            return new KekaForum.Models.Core.User
            {
                AccessToken = tokenJson,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Department = department.Name,
                Location = location.City
            };
        }

        public string GenerateToken(Models.Data.User userModel)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email , userModel.Email),
                new Claim(ClaimTypes.Name,userModel.UserName),
            };
            var algo = SecurityAlgorithms.HmacSha256;
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

            SigningCredentials signingCredentials = new SigningCredentials(secretKey, algo);
            //the json token representation of the jwt token
            var token = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(6),
                signingCredentials
            );
            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenJson;
        }
    }
}
