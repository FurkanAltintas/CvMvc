namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Type { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(75)]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Explanation { get; set; }

        [StringLength(250)]
        public string History { get; set; }
    }
}
