using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMvc.Models
{
    public class ProfileSocial
    {
        public Me me { get; set; }
        public Detail detail { get; set; }
        public IEnumerable<Appellation> appellation { get; set; }
        public IEnumerable<Social> social { get; set; }
    }
}