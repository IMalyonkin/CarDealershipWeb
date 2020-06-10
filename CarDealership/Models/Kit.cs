namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Kit
    {
        public Kit()
        {
            Kit_Option = new HashSet<Kit_Option>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ModelFK { get; set; }

        public virtual Model Model { get; set; }


        public virtual ICollection<Kit_Option> Kit_Option { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
