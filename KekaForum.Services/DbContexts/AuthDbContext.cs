using KekaForum.Services.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Services.DbContexts
{
    public class AuthDbContext:IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}
