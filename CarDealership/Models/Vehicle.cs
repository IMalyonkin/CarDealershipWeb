namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Vehicle
    {
        public Vehicle()
        {
            Contract = new HashSet<Contract>();
            Vehicle_Option = new HashSet<Vehicle_Option>();
        }

        public int Id { get; set; }

        [StringLength(17)]
        public string VIN { get; set; }

        public int EngineFK { get; set; }

        public int StatusFK { get; set; }

        public int? KitFK { get; set; }

        public int ColorFK { get; set; }

        public virtual Color Color { get; set; }

        public virtual Engine Engine { get; set; }

        public virtual Kit Kit { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Vehicle_Option> Vehicle_Option { get; set; }
    }
}
