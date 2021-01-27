using System;
using System.Collections.Generic;
using System.Text;

namespace KekaForum.Models.Core
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}
