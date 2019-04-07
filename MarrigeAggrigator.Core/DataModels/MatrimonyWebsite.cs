using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public class MatrimonyWebsite
    {
        [Key]
        public string WebSiteName { get; set; }

        public string Link { get; set; }

        public string Community { get; set; }

        public string Description { get; set; }

        public string IsFremium { get; set; }

        public string MotherTounge { get; set; }

        public string Religion { get; set; }

        public string SpecialCategory { get; set; }

        public List<MatrimonyProfile> Profiles { get; set; }

    }
}
