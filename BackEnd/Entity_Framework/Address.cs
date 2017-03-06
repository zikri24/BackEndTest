namespace BackEnd.Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string addrss1 { get; set; }

        public string addrss2 { get; set; }

        [StringLength(100)]
        public string Suburb { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [StringLength(10)]
        public string Postcode { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public virtual Merchant Merchant { get; set; }
    }
}
