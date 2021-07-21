using CvMvc.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CvMvc.Models
{
    public class ContactInformation
    {
        public Contact contact { get; set; }
        public Me me { get; set; }
    }
}