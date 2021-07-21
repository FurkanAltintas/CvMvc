namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Experience")]
    public partial class Experience
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string SoftwareLanguage { get; set; }

        [StringLength(250)]
        public string Explanation { get; set; }

        [StringLength(75)]
        public string History { get; set; }
    }
}
