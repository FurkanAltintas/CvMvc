using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMvc.Models
{
    public class NoteDetails
    {
        public IEnumerable<Note> note { get; set; }
        public Note Note { get; set; }
        public IEnumerable<NoteDetail> noteDetail { get; set; }
        public NoteDetail NoteDetail { get; set; }
    }
}