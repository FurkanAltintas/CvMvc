namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Social")]
    public partial class Social
    {
        public int Id { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Icon { get; set; }

        [StringLength(10)]
        public string Color { get; set; }
    }
}
