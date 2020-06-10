namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Option
    {
        public Option()
        {
            Kit_Option = new HashSet<Kit_Option>();
            Vehicle_Option = new HashSet<Vehicle_Option>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int ModelFK { get; set; }

        public int OptionTypeFK { get; set; }


        public virtual ICollection<Kit_Option> Kit_Option { get; set; }
        public virtual Model Model { get; set; }
        public virtual OptionType OptionType { get; set; }
        public virtual ICollection<Vehicle_Option> Vehicle_Option { get; set; }
    }
}
