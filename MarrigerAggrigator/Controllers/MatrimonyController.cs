using MarrigeAggrigator.Core;
using MarrigerAggrigator.Models;
using MarrigerAggrigator.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarrigerAggrigator.Controllers
{
    public class MatrimonyController : Controller
    {
        Adaptor adaptor = new Adaptor();
        static Matrimony matrimony = new Matrimony();
        static int counter = 1;


        public ActionResult ShowAllWebSitesWithProfiles()
        {
            return View(matrimony);
        }

        public ActionResult SearchPorfiles(Search search)
        {
            List<MatrimonyWebsite> allWebSites = new List<MatrimonyWebsite>();
            var dbResult = adaptor.GetAllWebSites(out allWebSites);

            List<MatrimonyWebsite> allFilteredWebSites = new List<MatrimonyWebsite>();
            //Filter result based on search data
            //Filter Data Based on Category
            var specialCategoryWebSites = allWebSites.Where(wb => !string.IsNullOrWhiteSpace(wb.SpecialCategory) && wb.SpecialCategory.ToLower() == search.specialCategory.ToLower()).ToList();
            if (specialCategoryWebSites.Any())
            {
                allFilteredWebSites.AddRange(specialCategoryWebSites);
            }

            //Filter Community WebSites
            var communityWebSites = allWebSites.Where(wb => !string.IsNullOrWhiteSpace(wb.Community) && wb.Community.ToLower() == search.community.ToLower()).ToList();
            if (communityWebSites.Any())
            {
                allFilteredWebSites.AddRange(communityWebSites);
            }

            //Filter Religion and Mothertounge
            var religionandMotherTounge = allWebSites.Where(wb => !string.IsNullOrWhiteSpace(wb.Religion) && !string.IsNullOrWhiteSpace(wb.MotherTounge) && wb.Religion.ToLower() == search.religion.ToLower() && wb.MotherTounge.ToLower() == search.motherTounge.ToLower()).ToList();
            if (religionandMotherTounge.Any())
            {
                allFilteredWebSites.AddRange(religionandMotherTounge);
            }

            //Filter Religion
            if (search.religion != "Hindu")
            {
                var religion = allWebSites.Where(wb => !string.IsNullOrWhiteSpace(wb.Religion) && wb.Religion.ToLower() == search.religion.ToLower()).ToList();
                if (religion.Any())
                {
                    allFilteredWebSites.AddRange(religion);
                }
            }


            var motherTounge = allWebSites.Where(wb => !string.IsNullOrWhiteSpace(wb.MotherTounge) && wb.MotherTounge.ToLower() == search.motherTounge.ToLower()).ToList();
            if (motherTounge.Any())
            {
                allFilteredWebSites.AddRange(motherTounge);
            }

            allFilteredWebSites = allFilteredWebSites.GroupBy(website => website.WebSiteName).Select(web => web.First()).ToList();



            if (allFilteredWebSites.Any())
            {
                matrimony.AllWebSites = allFilteredWebSites;
                foreach (var website in allFilteredWebSites)
                {
                    website.Profiles = GetAllProfiles(website.WebSiteName);
                    if (counter == 107) counter = 0;
                    if (search.Gender == Constants.Female && search.community == Constants.Muslim)
                    {
                        website.Profiles.ForEach(profile => profile.ProfilePicPath = "./ProfilePictures_Muslim/" + counter++ + ".jpg");
                    }
                    else if (search.Gender == Constants.Female)
                    {
                        website.Profiles.ForEach(profile => profile.ProfilePicPath = "./ProfilePictures_Bride/" + counter++ + ".jpg");
                    }
                    else if (search.Gender == Constants.Male)
                    {
                        website.Profiles.ForEach(profile => profile.ProfilePicPath = "./ProfilePictures_Groom/" + counter++ + ".jpg");
                    }

                }
            }
            return Json(new

            {
                redirectTo = Url.Action("ShowAllWebSitesWithProfiles", "Matrimony"),
                returnParam = matrimony
            });
        }

        public JsonResult GetSearchMetaData()
        {
            List<MatrimonyWebsite> allWebSites = new List<MatrimonyWebsite>();
            var dbResult = adaptor.GetAllWebSites(out allWebSites);

            SearchMetaData searchMetaData = new SearchMetaData
            {
                Community = allWebSites.Where(webSite => !string.IsNullOrWhiteSpace(webSite.Community)).ToList().GroupBy(webSite => webSite.Community).Select(webSite => webSite.First()).Select(webSite => webSite.Community.ToLower()).ToList(),
                MotherTounge = allWebSites.Where(webSite => !string.IsNullOrWhiteSpace(webSite.MotherTounge)).ToList().GroupBy(webSite => webSite.MotherTounge).Select(webSite => webSite.First()).Select(webSite => webSite.MotherTounge.ToLower()).ToList(),
                Religion = allWebSites.Where(webSite => !string.IsNullOrWhiteSpace(webSite.Religion)).ToList().GroupBy(webSite => webSite.Religion).Select(webSite => webSite.First()).Select(webSite => webSite.Religion.ToLower()).ToList(),
                SpecialCategory = allWebSites.Where(webSite => !string.IsNullOrWhiteSpace(webSite.SpecialCategory)).ToList().GroupBy(webSite => webSite.SpecialCategory).Select(webSite => webSite.First()).Select(webSite => webSite.SpecialCategory.ToLower()).ToList()
            };

            searchMetaData.Community = searchMetaData.Community.MoveToTop().ToList();
            searchMetaData.MotherTounge = searchMetaData.MotherTounge.MoveToTop().ToList();
            searchMetaData.Religion = searchMetaData.Religion.MoveToTop().ToList();
            searchMetaData.SpecialCategory = searchMetaData.SpecialCategory.MoveToTop().ToList();

            return Json(searchMetaData);
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