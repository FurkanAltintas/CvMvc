namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Hood { get; set; }

        [StringLength(150)]
        public string Explanation { get; set; }
    }
}
