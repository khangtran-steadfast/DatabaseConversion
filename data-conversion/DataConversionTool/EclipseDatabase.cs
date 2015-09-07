using AutoMapper;
using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DataConversion;
using DataConversion.DatabaseMapper;
using DataConversionTool.ManualMappingTable;
namespace DataConversionTool
{
    class EclipseDatabase : SourceDatabase
    {
        /// <summary>
        /// Create EclipseDatabase as SourceDatabase
        /// </summary>
        public EclipseDatabase() : base(typeof(EclipseDataAccess.EclipseDatabaseEntities))
        {
            //
            // Create connection to EclipseDatabase
            LogService.Log.Info("Creating connection to eClipse database.");
            try
            {
                this._dbContext = new EclipseDataAccess.EclipseDatabaseEntities();
            }
            catch (Exception excConnectToDatabase)
            {
                int EXIT_SUCCESSFULL = 0;
                LogService.Log.Error("Can not connect to eClipse database. Please check your connection string and try later.", excConnectToDatabase);
                Environment.Exit(EXIT_SUCCESSFULL);
            }

            //
            // Learn eClipse schema
            LogService.Log.Info("Learning eClipse schema.");
            this.Initialize();
        }
        
        /// <summary>
        /// Return new DbContext of EclipseDatabase
        /// </summary>
        /// <returns></returns>
        public override DbContext GetNewDbContext()
        {
            return new EclipseDataAccess.EclipseDatabaseEntities();
        }
    }
}