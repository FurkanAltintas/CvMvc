namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Portfolio")]
    public partial class Portfolio
    {
        public int Id { get; set; }

        public int? PortfolioCategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Explanation { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? History { get; set; }
    }
}
