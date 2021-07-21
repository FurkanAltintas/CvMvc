namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        [StringLength(75)]
        public string Email { get; set; }

        public string Message { get; set; }

        [Column(TypeName = "date")]
        public DateTime? History { get; set; }

        public TimeSpan? Time { get; set; }
    }
}
