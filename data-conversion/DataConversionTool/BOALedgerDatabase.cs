﻿using AutoMapper;
using DataConversion;
using DataConversion.DatabaseMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace DataConversionTool
{
    class BOALedgerDatabase : DestinationDatabase
    {
        #region CONSTRUCTOR, INTIIALIZE
        
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public BOALedgerDatabase() : base(typeof(BOALedgerDataAccess.BOALedgerEntities))
        {
            //
            // Create connection to EclipseDatabase
            LogService.Log.Info("Creating connection to BOALedger database.");
            try
            {
                this._dbContext = new BOALedgerDataAccess.BOALedgerEntities();
            }
            catch (Exception excConnectToDatabase)
            {
                int EXIT_SUCCESSFULL = 0;
                LogService.Log.Error("Can not connect to BOALedger database.  Please check your connection string and try later.", excConnectToDatabase);
                Environment.Exit(EXIT_SUCCESSFULL);
            }


            //
            // Learn eClipse schema
            LogService.Log.Info("Learning BOALedger schema.");
            this.Initialize();
            this.RemoveTable("systemdiagram");


            //
            // Configure map order
            LogService.Log.Info("Configuring special map order for BOALedger database.");
            this.IngoreReferenceWhenGetMapOrder("branches", "branches");
            this.IngoreReferenceWhenGetMapOrder("general_insurance", "workbooks");
            this.IngoreReferenceWhenGetMapOrder("general_insurance", "policies");
            this.MapAfter("gl_movements", "write_off");
            this.MapAfter("gl_movements", "cash_receipts");
            this.MapAfter("gl_movements", "cash_payments");
            this.MapAfter("gl_movements", "gl_journal");
            this.MapAfter("gl_movements", "policies");
            this.MapAfter("gl_movements", "pay_direct");
            this.MapAfter("gl_movements", "cash_receipt_reversal");
        }


        #endregion


        #region METHODS
        

        /// <summary>
        /// Get new DbContext
        /// </summary>
        /// <returns></returns>
        public override DbContext GetNewDbContext()
        {
            return new BOALedgerDataAccess.BOALedgerEntities();
        }
                      

        #endregion


        #region FUNCTION GENERATE CODE FOR AUTOMAPPER


        /// <summary>
        /// Genereate code for configuring automapper
        /// </summary>
        /// <param name="filePath"></param>
        public void GenerateAutoMapperConfiguration(string filePath)
        {
            //
            // Initialize
            StreamWriter writer = new StreamWriter(filePath);
            string mainTemplate = "Mapper.CreateMap<EclipseDataAccess.{TABLE}, BOALedgerDataAccess.{TABLE}>().ConvertUsing(CustomMapper_{TABLE})";


            //
            // Get all table to map
            List<string> listTables = this.GetListTable();
            foreach (string table in listTables)
            {
                //
                // Check
                // Try to get DbSet from table
                // If can not get, this table don't have primary key
                // So we don't need to config automapper for this table
                DbSet dbSet = this.GetTable(table);
                if (dbSet == null)
                {
                    continue;
                }

                //
                // Write out first config
                writer.Write(mainTemplate.Replace("{TABLE}", table));


                //
                // Ok, done with this table
                writer.WriteLine(";");
            }


            //
            // Done
            writer.Close();
        }

        /// <summary>
        /// Generate custom mapper function
        /// </summary>
        /// <param name="filePath"></param>
        public void GenerateCustomMapperFunction(string filePath)
        {
            //
            // Initialize
            StreamWriter writer = new StreamWriter(filePath);
            string PARAM_SOURCE = "\"source\"";
            string TEMPLATE = @"
                    /// <summary>
                    /// Custom mapper function for {TABLE} table
                    /// </summary>
                    /// <param name={PARAM_SOURCE}></param>
                    /// <returns></returns>
		            protected BOALedgerDataAccess.{TABLE} CustomMapper_{TABLE}(EclipseDataAccess.{TABLE} source)
                    {
                        //
                        // Initialize result
                        BOALedgerDataAccess.{TABLE} destination = new BOALedgerDataAccess.{TABLE}();
                        //
                        // Set basic properties
                        {SET_BASIC_PROPERTIES}
                        //
                        // Return result
                        return destination;
                    }";


            //
            // Get all table to map
            List<string> listTables = this.GetListTable();
            foreach (string table in listTables)
            {
                //
                // Check
                // Try to get DbSet from table
                // If can not get, this table don't have primary key
                // So we don't need to config automapper for this table
                DbSet dbSet = this.GetTable(table);
                if (dbSet == null)
                {
                    continue;
                }


                //
                // Try to generate code
                string SET_BASIC_PROPERTIES = this.GetBasicPropertiesCode(table);


                //
                // Write to file
                string code = TEMPLATE.Replace("{TABLE}", table)
                                      .Replace("{PARAM_SOURCE}", PARAM_SOURCE)
                                      .Replace("{SET_BASIC_PROPERTIES}", SET_BASIC_PROPERTIES);
                writer.WriteLine(code);
                writer.WriteLine();
            }


            //
            // Done
            writer.Close();
        }

        /// <summary>
        /// Genereate code to set table value
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public string GetBasicPropertiesCode(string table)
        {
            //
            // Initialize result
            string result = "";
            string sql = @"select column_name
                           from information_schema.columns
                           where table_name = '{TABLE}'";

            //
            // Try to invoke procedure
            List<string> listColumns = this._dbContext.Database.SqlQuery<string>(sql.Replace("{TABLE}", table)).ToList();
            bool first = true;
            foreach (string column in listColumns)
            {
                string code = "";
                if (column.Equals("RowVersion"))
                {
                    continue;
                }
                if (first)
                {
                    first = false;
                    code = "destination." + column + " = " + "source." + column + ";" + System.Environment.NewLine;
                }
                else
                {
                    code = "\t\t\t\t\t\tdestination." + column + " = " + "source." + column + ";" + System.Environment.NewLine;
                }
                result = result + code;
            }


            //
            // Return result
            return result;
        }
        

        #endregion
    }
}