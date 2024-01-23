using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
            Users = new HashSet<User>();
        }

        public int ChatId { get; set; }
        public int AdId { get; set; }
        public int UserId { get; set; }

        public virtual Advertisement Ad { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
