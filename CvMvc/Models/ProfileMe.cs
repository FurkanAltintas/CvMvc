using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMvc.Models
{
    public class ProfileMe
    {
        public Me me { get; set; }
        public Education education { get; set; }
        public About about { get; set; }
        public IEnumerable<Skill> skill { get; set; }
        public IEnumerable<Appellation> appellation { get; set; }
        public IEnumerable<Portfolio> portfolio { get; set; }
    }
}