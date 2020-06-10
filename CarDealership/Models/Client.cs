namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Client
    {
        public Client()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
