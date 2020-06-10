namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Color
    {
        public Color()
        {
            Model_Color = new HashSet<Model_Color>();
            Vehicle = new HashSet<Vehicle>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Model_Color> Model_Color { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
