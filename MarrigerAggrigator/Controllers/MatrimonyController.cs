using MarrigeAggrigator.Core;
using MarrigerAggrigator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarrigerAggrigator.Controllers
{
    public class MatrimonyController : Controller
    {
        Adaptor adaptor = new Adaptor();
        Matrimony matrimony = new Matrimony();

        // GET: Matrimony
        public ActionResult ShowAllWebSitesWithProfiles()
        {
            List<MatrimonyWebsite> allWebSites = new List<MatrimonyWebsite>();
            var dbResult = adaptor.GetAllWebSites(out allWebSites);
            if (allWebSites.Any())
            {
                matrimony.AllWebSites = allWebSites;
                foreach (var website in allWebSites)
                {
                    website.Profiles = GetAllProfiles(website.WebSiteName);
                }
            }
            return View(matrimony);
        }

        private List<MatrimonyProfile> GetAllProfiles(string websiteName)
        {
            try
            {
                List<MatrimonyProfile> allProfiles = new List<MatrimonyProfile>();
                var dbResult = adaptor.GetAllProfiles(out allProfiles);
                return allProfiles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}