namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class References
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(250)]
        public string Profile { get; set; }

        [StringLength(100)]
        public string Profession { get; set; }

        [StringLength(150)]
        public string Explanation { get; set; }
    }
}
