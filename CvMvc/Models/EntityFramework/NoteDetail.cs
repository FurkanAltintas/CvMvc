namespace CvMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoteDetail")]
    public partial class NoteDetail
    {
        public int Id { get; set; }

        public int? NoteId { get; set; }

        public string Detail { get; set; }

        public DateTime? History { get; set; }

        public bool? Status { get; set; }

        public virtual Note Note { get; set; }
    }
}
