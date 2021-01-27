using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Models.Core
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string AccessToken { get; set; }
    }
}
