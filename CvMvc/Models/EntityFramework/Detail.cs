namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detail")]
    public partial class Detail
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
    }
}
