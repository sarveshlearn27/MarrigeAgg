using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarrigeAggrigator.Core
{
    public class MatrimonyProfile
    {
        [Key]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Community { get; set; }

        public string ProfilePicPath { get; set; }

        public MatrimonyWebsite WebSiteOfProfile { get; set; }

        public string WebSiteName { get; set; }
    }
}
