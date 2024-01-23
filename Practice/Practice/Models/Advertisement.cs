using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            Chats = new HashSet<Chat>();
        }

        public int AdId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int AdStatusId { get; set; }
        public string Title { get; set; } = null!;
        public string? Discription { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditTime { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }

        public virtual AdStatus AdStatus { get; set; } = null!;
        public virtual Car Car { get; set; } = null!;
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
