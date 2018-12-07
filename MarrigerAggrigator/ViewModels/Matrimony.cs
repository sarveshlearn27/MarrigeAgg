using MarrigeAggrigator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarrigerAggrigator.ViewModels
{
    public class Matrimony
    {
        public IEnumerable<MatrimonyWebsite> AllWebSites { get; set; }

        public IEnumerable<MatrimonyProfile> AllProfiles { get; set; }
    }
}