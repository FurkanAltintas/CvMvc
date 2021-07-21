namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appellation")]
    public partial class Appellation
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
