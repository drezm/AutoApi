using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Model
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public int ModelId { get; set; }
        public string Model1 { get; set; } = null!;
        public string Brand { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; }
    }
}
