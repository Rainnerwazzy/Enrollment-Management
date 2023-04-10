﻿using IdentityModel;
using JWTAuthorization.Api.Configuration;
using JWTAuthorization.Api.Data;
using JWTAuthorization.Api.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTAuthorization.Api.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(ApplicationDbContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public async Task Initialize()
        {
                      
           await _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client));
    
            ApplicationUser client = new ApplicationUser()
            {
                UserName = "universidade-client",
                Email = "universidade-client@universidade.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (62) 12345-6789",
                FirstName = "Universidade",
                LastName = "Client"
            };

            await _user.CreateAsync(client, "Rainner123$");
            await _user.AddToRoleAsync(client, IdentityConfiguration.Client);

            var clientClaims = await _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            });
        }
    }
}
