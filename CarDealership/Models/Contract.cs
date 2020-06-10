namespace CarDealership.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Contract
    {
        public int Id { get; set; }

        [Column("Total Price")]
        public decimal Total_Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int VehicleFK { get; set; }

        public int ClientFK { get; set; }

        public virtual Client Client { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
