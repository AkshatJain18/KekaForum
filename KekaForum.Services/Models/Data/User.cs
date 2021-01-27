using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Services.Models.Data
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string ProfilePicUrl { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
    }
}
