using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public int OTP { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}