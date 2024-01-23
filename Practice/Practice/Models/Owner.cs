using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Owner
    {
        public int OwnnerId { get; set; }
        public int UserId { get; set; }
        public DateTime? TenurePeriodFrom { get; set; }
        public DateTime? TenurePeriodTo { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
