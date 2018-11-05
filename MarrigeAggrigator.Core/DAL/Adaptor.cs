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

        public Result FillAllProfileDetailsToDb(string filePath)
        {
            Result result = new Result();
            try
            {
                //For Now Reading Data From Excel
                var excelParser = new ExcelParser();
                var distinctWebSites = excelParser.ReadExcel(filePath).GroupBy(wb => wb.WebSiteName).Select(wb => wb.FirstOrDefault()).ToList();
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

        public Result UpdateProfile()
        {
            throw new NotImplementedException();
        }

        public Result ViewProfile()
        {
            throw new NotImplementedException();
        }
    }
}
