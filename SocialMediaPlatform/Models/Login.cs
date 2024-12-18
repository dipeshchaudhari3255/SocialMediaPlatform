using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Models
{
    public class Login : EmailAddress
    {
        public string? PasswordHash { get; set; }

    }
}