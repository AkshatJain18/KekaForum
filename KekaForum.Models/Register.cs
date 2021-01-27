using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Models.Core
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
    }
}
