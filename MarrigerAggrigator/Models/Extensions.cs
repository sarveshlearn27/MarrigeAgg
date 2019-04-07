using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MarrigerAggrigator.Models
{
    public static class Extensions
    {
        public static List<string> MoveToTop<T>(this IList<T> source)
        {
            var newSeq = new List<string>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            foreach (var sc in source)
            {
                newSeq.Add(textInfo.ToTitleCase(sc.ToString()));
            }

            return newSeq ;
        }
    }
}