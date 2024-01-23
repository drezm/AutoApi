using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditTime { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string Contents { get; set; } = null!;
        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; } = null!;
    }
}
