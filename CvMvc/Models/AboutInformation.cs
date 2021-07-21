using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMvc.Models
{
    public class AboutInformation
    {
        public About About { get; set; }
        public Me Me { get; set; }
    }
}