using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int? SenderId { get; set; }
        public User Sender { get; set; }
        public int? ReceiverId { get; set; }
        public User? Receiver { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}