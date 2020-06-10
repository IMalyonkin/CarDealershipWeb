namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Model
    {
        public Model()
        {
            Kit = new HashSet<Kit>();
            Model_Color = new HashSet<Model_Color>();
            Model_Engine = new HashSet<Model_Engine>();
            Option = new HashSet<Option>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int BrandFK { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Kit> Kit { get; set; }
        public virtual ICollection<Model_Color> Model_Color { get; set; }
        public virtual ICollection<Model_Engine> Model_Engine { get; set; }
        public virtual ICollection<Option> Option { get; set; }
    }
}
