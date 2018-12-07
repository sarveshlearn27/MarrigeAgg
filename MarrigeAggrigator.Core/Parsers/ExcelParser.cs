using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public class ExcelParser
    {
        /// <summary>
        /// Read Matrimony Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<MatrimonyWebsite> ReadmatrimonyExcel(string filePath)
        {
            try
            {
                string currentyDirectory = filePath;

                #region Read Excel
                DataSet dtExcel = new DataSet();
                using (var stream = File.Open(currentyDirectory, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                            }
                        }
                        while (reader.NextResult());
                        dtExcel = reader.AsDataSet();
                    }
                }
                #endregion

                return GetAllMatrimonyWebSites(dtExcel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get All MatrimonyWebsites
        /// </summary>
        /// <param name="dtExcel"></param>
        /// <returns></returns>
        private List<MatrimonyWebsite> GetAllMatrimonyWebSites(DataSet dtExcel)
        {
            try
            {
                var tables = dtExcel.Tables;
                List<MatrimonyWebsite> allWebSites = new List<MatrimonyWebsite>();

                foreach (DataTable table in tables)
                {
                    DataRowCollection allRows = table.Rows;
                    for (int i = 1; i < allRows.Count; i++)
                    {
                        MatrimonyWebsite matriMonyWebSite = new MatrimonyWebsite();

                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            matriMonyWebSite.WebSiteName = allRows[i][j].ToString();
                            j++;
                            matriMonyWebSite.Link = allRows[i][j].ToString();
                            j++;
                            matriMonyWebSite.Community = allRows[i][j].ToString();
                            j++;
                            matriMonyWebSite.IsFremium = allRows[i][j].ToString();
                            break;
                        }
                        allWebSites.Add(matriMonyWebSite);
                    }
                }

                return allWebSites;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<MatrimonyProfile> ReadProfileExcel(string filePath)
        {
            try
            {
                string currentyDirectory = filePath;

                #region Read Excel
                DataSet dtExcel = new DataSet();
                using (var stream = File.Open(currentyDirectory, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                            }
                        }
                        while (reader.NextResult());
                        dtExcel = reader.AsDataSet();
                    }
                }
                #endregion

                return GettAllMatrimonyProfiles(dtExcel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<MatrimonyProfile> GettAllMatrimonyProfiles(DataSet dtExcel)
        {
            try
            {
                var tables = dtExcel.Tables;
                List<MatrimonyProfile> allProfiles = new List<MatrimonyProfile>();

                foreach (DataTable table in tables)
                {
                    DataRowCollection allRows = table.Rows;
                    for (int i = 1; i < allRows.Count; i++)
                    {
                        MatrimonyProfile matrimonyProfile = new MatrimonyProfile();

                        for (int j = 0; j < table.Columns.Count; j++)
                        {
                            matrimonyProfile.Name = allRows[i][j].ToString();
                            j++;
                            matrimonyProfile.Age = Convert.ToInt32(allRows[i][j].ToString());
                            j++;
                            matrimonyProfile.Community = allRows[i][j].ToString();
                            j++;
                            matrimonyProfile.ProfilePicPath = allRows[i][j].ToString();
                            j++;
                            matrimonyProfile.WebSiteName = allRows[i][j].ToString();
                            j++;
                            matrimonyProfile.Sex = allRows[i][j].ToString();
                            break;
                        }
                        allProfiles.Add(matrimonyProfile);
                    }
                }

                return allProfiles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
