using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Car
    {
        public Car()
        {
            Advertisements = new HashSet<Advertisement>();
            Owners = new HashSet<Owner>();
        }

        public int CarId { get; set; }
        public int ModelId { get; set; }
        public int CarStatusId { get; set; }
        public int UserId { get; set; }
        public int ManufacturingYear { get; set; }
        public int? Mileage { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Color { get; set; } = null!;

        public virtual CarStatus CarStatus { get; set; } = null!;
        public virtual Model Model { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
    }
}
