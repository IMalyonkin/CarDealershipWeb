namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Engine
    {
        public Engine()
        {
            Model_Engine = new HashSet<Model_Engine>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public decimal Power { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Model_Engine> Model_Engine { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
