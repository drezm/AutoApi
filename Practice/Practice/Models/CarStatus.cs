using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class CarStatus
    {
        public CarStatus()
        {
            Cars = new HashSet<Car>();
        }

        public int CarStatusId { get; set; }
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
