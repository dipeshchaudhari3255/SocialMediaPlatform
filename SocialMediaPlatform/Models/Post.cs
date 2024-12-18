using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string? Content { get; set; }
        public string? MediaUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}