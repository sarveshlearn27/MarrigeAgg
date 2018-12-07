using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core
{
    public interface IDBAdaptor
    {
        /// <summary>
        /// Fill All Profile Details to db from dataSource
        /// </summary>
        /// <returns></returns>
        Result FillAllWebSitesToDB(string filePath);

        /// <summary>
        /// Add Profile to db
        /// </summary>
        /// <returns></returns>
        Result AddProfile();

        /// <summary>
        /// Update Profile to db
        /// </summary>
        /// <returns></returns>
        Result UpdateProfile();

        /// <summary>
        /// View Profile Details
        /// </summary>
        /// <returns></returns>
        Result ViewProfile();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Result FillAllProfilesToDB(string filePath);

    }
}
