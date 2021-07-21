namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Me
    {
        public int Id { get; set; }

        public int? AdminId { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(250)]
        public string Profile { get; set; }

        public short? Age { get; set; }

        [StringLength(75)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Language { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
