using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public class Adaptor : IDBAdaptor
    {

        public Result AddProfile()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fill All WebSites to Db
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Result FillAllWebSitesToDB(string filePath)
        {
            Result result = new Result();
            try
            {
                //For Now Reading Data From Excel
                var excelParser = new ExcelParser();
                var distinctWebSites = excelParser.ReadmatrimonyExcel(filePath).GroupBy(wb => wb.WebSiteName).Select(wb => wb.FirstOrDefault()).ToList();
                //Enter Data To db
                using (var modelContext = new ModelContext())
                {
                    foreach (var webSite in distinctWebSites)
                    {
                        modelContext.MartrimonyWebSites.Add(webSite);
                        modelContext.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Fill All Profiles to Db
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Result FillAllProfilesToDB(string filePath)
        {
            Result result = new Result();
            try
            {
                //For Now Reading Data From Excel
                var excelParser = new ExcelParser();
                var distinctProfiles = excelParser.ReadProfileExcel(filePath).GroupBy(wb => wb.WebSiteName).Select(wb => wb.FirstOrDefault()).ToList();
                //Enter Profile Data To db
                using (var modelContext = new ModelContext())
                {
                    foreach (var profile in distinctProfiles)
                    {
                        modelContext.Profiles.Add(profile);
                        modelContext.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public Result UpdateProfile()
        {
            throw new NotImplementedException();
        }

        public Result ViewProfile()
        {
            throw new NotImplementedException();
        }

        public Result GetAllWebSites(out List<MatrimonyWebsite> allWebsites)
        {
            allWebsites = new List<MatrimonyWebsite>();
            Result result = new Result();
            result.ErrorCode = (ulong)ResultCode.SUCCESS;

            try
            {
                using (var modelContext = new ModelContext())
                {
                    allWebsites = modelContext.MartrimonyWebSites.ToList();
                }
                allWebsites.ForEach(website => website.WebSiteName = string.Format(Constants.Viewprofile, website.WebSiteName));
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Result GetAllProfiles(out List<MatrimonyProfile> allProfiles)
        {
            allProfiles = new List<MatrimonyProfile>();
            Result result = new Result
            {
                ErrorCode = (ulong)ResultCode.SUCCESS
            };
            try
            {
                using (var modelContext = new ModelContext())
                {
                    allProfiles = modelContext.Profiles.ToList();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
