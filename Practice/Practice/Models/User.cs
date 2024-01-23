using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
            Chats = new HashSet<Chat>();
            Owners = new HashSet<Owner>();
            ChatsNavigation = new HashSet<Chat>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
        public string? Location { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditTime { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }

        public virtual ICollection<Chat> ChatsNavigation { get; set; }
    }
}
