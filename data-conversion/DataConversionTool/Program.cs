using DataConversion;
using DataConversion.DatabaseMapper;
using DataConversion.DatabaseMapper.DataValidation;
using DataConversion.DatabaseMapper.ErrorHandler;
using System;
using System.Linq;
using System.Collections.Generic;
using DataConversion.DatabaseMapper.DataValidation.Orphan;
using System.IO;
using DataConversionTool.ManualMappingTable;
using System.Diagnostics;
namespace DataConversionTool
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            //
            // Initialize source and destination database
            Initialize(args);
            EclipseDatabase source = new EclipseDatabase();
            BOALedgerDatabase destination = new BOALedgerDatabase();
            MappingManager manager = new MappingManager(source, destination);
            manager.ChangeName("ledgers", "gl_ledgers");

            //
            // Check we need to validate or not
            if (args.Contains("/report-data-errors"))
            {
                LogService.Log.Info("Running data validation.");
                ValidationManager validationManager = new ValidationManager();
                validationManager.Validate<OrphanRecordValidation>(manager, source, destination);
                return;
            }


            //
            // Configure maping manager
            manager.ConfigAutoMapper(new EclipseToBOALedgerProfile());
            ConfigureManualMapping(manager);
            ConfigurePreConversionScript(manager);
            ConfigurePostMigrationScript(manager);
            SetRunningMode(manager, args);


            //
            // Start mapping
            try
            {
                manager.Map();
                if (manager.IsGeneratedScript)
                {
                    RunBatFile(manager);
                }
            }
            catch (Exception exc)
            {
                LogService.Log.Error("Error occurs when mapping. Terminated.", exc);
            }
        }

        /// <summary>
        /// Initialize for mapping manager
        /// </summary>
        /// <param name="manager">Mapping manager</param>
        /// <param name="ignoreBlobs">Flag to ingore blob pointer</param>
        private static void Initialize(string[] args)
        {
            //
            // Configure logservice
            DataConversion.LogService.Initialize(typeof(Program));
            

            //
            // Apose license
            Aspose.Words.License word = new Aspose.Words.License();
            word.SetLicense("Aspose.Total.lic");
            Aspose.Cells.License excel = new Aspose.Cells.License();
            excel.SetLicense("Aspose.Total.lic");


            //
            // Configure blob pointer
            bool ignoreBlobs = false;
            if (args.Contains("/ignore-blobs"))
            {
                ignoreBlobs = true;
            }
            ManualMapping.IgnoreBlobs = ignoreBlobs;
        }

        /// <summary>
        /// Configure manual mapping
        /// </summary>
        /// <param name="manager"></param>
        private static void ConfigureManualMapping(MappingManager manager)
        {
            //
            // These manual mapping function
            // For table does not have primary key
            // So we need to map through SQL Script
            manager.AddManualMapping("ageing_debtors_v", new ManualMapping_ageing_debtors_v());
            manager.AddManualMapping("atura_identity", new ManualMapping_atura_identity());
            manager.AddManualMapping("Cash_Receipt_Lock", new ManualMapping_Cash_Receipt_Lock());
            manager.AddManualMapping("expiry_register_particulars_t", new ManualMapping_expiry_register_particulars_t());
            manager.AddManualMapping("glsl_Transactions", new ManualMapping_glsl_Transactions());
            manager.AddManualMapping("IBA", new ManualMapping_IBA());
            manager.AddManualMapping("period_renewals_particulars_t", new ManualMapping_period_renewals_particulars_t());
            manager.AddManualMapping("renewal_retention_report", new ManualMapping_renewal_retention_report());
            manager.AddManualMapping("statements", new ManualMapping_statements());
            manager.AddManualMapping("tmpPortfolioAnalysis", new ManualMapping_tmpPortfolioAnalysis());
            manager.AddManualMapping("turnover", new ManualMapping_turnover());
            manager.AddManualMapping("view_DofiReport_Table1", new ManualMapping_view_DofiReport_Table1());
            manager.AddManualMapping("view_DofiReport_Table2", new ManualMapping_view_DofiReport_Table2());
            manager.AddManualMapping("view_earnings", new ManualMapping_view_earnings());
            manager.AddManualMapping("view_earnings2", new ManualMapping_view_earnings2());
            manager.AddManualMapping("view_inspay", new ManualMapping_view_inspay());
            manager.AddManualMapping("vims_EarningsDiff", new ManualMapping_vims_EarningsDiff());
            manager.AddManualMapping("vims_unallocated_csh_credits", new ManualMapping_vims_unallocated_csh_credits());
            manager.AddManualMapping("PaidInvoices", new ManualMapping_PaidInvoices());
            manager.AddManualMapping("policies_converted", new ManualMapping_policies_converted());

            ////
            //// Add manual mapping
            //// To map table has circle references
            //// Or table has difficult references
            manager.AddManualMapping("branches", new ManualMapping_branches());
            manager.AddManualMapping("general_insurance", new ManualMapping_general_insurance());
            manager.AddManualMapping("workbooks", new ManualMapping_workbooks());


            //
            // Add manual mapping
            // To override mapping function with table doesn't need anymore
            // So just create EMPTY mapping function to improve performance
            manager.AddManualMapping("Workbook_SOA", new ManualMapping_Workbook_SOA());
            manager.AddManualMapping("BackgroundJobs", new ManualMapping_BackgroundJobs());
            manager.AddManualMapping("SteadfastReport", new ManualMapping_SteadfastReport());


            //
            // Add manual mapping
            // To map table has Image field need convert to blob pointer
            manager.AddManualMapping("claim_sub_tasks", new ManualMapping_claim_sub_tasks());
            manager.AddManualMapping("journal_sub_tasks", new ManualMapping_journal_sub_tasks());
            manager.AddManualMapping("tasks_sub_tasks", new ManualMapping_tasks_sub_tasks());
            manager.AddManualMapping("general_general_insurance_workbooks", new ManualMapping_general_insurance_workbooks());
            manager.AddManualMapping("policy_transaction_documents", new ManualMapping_policy_transaction_documents());
            manager.AddManualMapping("claim_documents", new ManualMapping_claim_documents());
            manager.AddManualMapping("gen_ins_documents", new ManualMapping_gen_ins_documents());
            manager.AddManualMapping("task_documents", new ManualMapping_task_documents());
            manager.AddManualMapping("confirmation_of_cover", new ManualMapping_confirmation_of_cover());
            manager.AddManualMapping("notes", new ManualMapping_notes());
            manager.AddManualMapping("DocumentRepository", new ManualMapping_DocumentRepository());
            manager.AddManualMapping("EmailTemplates", new ManualMapping_EmailTemplates());
            manager.AddManualMapping("client_insurance_portfolio", new ManualMapping_client_insurance_portfolio());
            manager.AddManualMapping("policies", new ManualMapping_policies());
            manager.AddManualMapping("soa_clauses", new ManualMapping_soa_clauses());
        }

        /// <summary>
        /// Configure pre-conversion script
        /// </summary>
        /// <param name="manager"></param>
        private static void ConfigurePreConversionScript(MappingManager manager)
        {
            //
            // These script will run before mapping in EclipseDatabase
            manager.AddPreConversionScript(@"SQLScript\3.2.2.AddNewField.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.3.CreatePolicyRecords.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.4.UpdatePoliciesTable.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.5.UpdateJournalsTable.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.6.UpdateWorkbook_NotesTable.sql");
        }

        /// <summary>
        /// Configure post migration script
        /// </summary>
        /// <param name="manager"></param>
        private static void ConfigurePostMigrationScript(MappingManager manager)
        {
            //
            // Set post-migration script to run after mapping
            manager.AddPostMigrationScript(@"SQLScript\3.2.7.PopulateCurrentPolicy.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.1.EntityBalance.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.2.PolicyBalance.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.3.PolicyInsured.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.5.AutoPolicyNumber.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.6.EditBrokerRepWorkbook.sql");
            manager.AddPostMigrationScript(@"SQLScript\4.7.MandatoryFields.sql");
        }

        /// <summary>
        /// Set running mode, execute SQL script or extract
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="args"></param>
        private static void SetRunningMode(MappingManager manager, string[] args)
        {
            //
            // Check args contains /run-sql or not
            // If it contains
            // We will execute SQL script directly
            if(args.Any(x => x.Equals("/run-sql")))
            {
                LogService.Log.Info("Mapping manager will execute SQL script.");
            }
            else
            {
                //
                // Check we need to extract SQL script or not
                bool hasParameter = false;
                foreach (string arg in args)
                {
                    if (arg.Contains("/export-script"))
                    {
                        hasParameter = true;
                        try
                        {
                            string[] argSplit = arg.Split(':');
                            string folder = "Output";
                            if (argSplit.Count() == 2 && argSplit.Last().Equals("") == false)
                            {
                                folder = argSplit.Last();
                            }
                            manager.SetDirectoryPath(folder);
                            LogService.Log.Info("-------------------------------------------");
                            LogService.Log.Info("Export SQL Script to " + folder);
                        }
                        catch (Exception exc)
                        {
                            LogService.Log.Error("Can not get folder path to store SQL script.", exc);
                            LogService.Log.Info("Make default folder to store SQL Script is : Output");
                            manager.SetDirectoryPath("Output");
                            return;
                        }
                    }
                }


                //
                // This code make sure that
                // We always extract SQL script
                if (hasParameter == false)
                {
                    manager.SetDirectoryPath("Output");
                }
            }
        }

        /// <summary>
        /// Run bat file
        /// </summary>
        /// <param name="manager"></param>
        private static void RunBatFile(MappingManager manager)
        {
            //
            // If everything is okay
            // Prompt user to run it or not ?
            bool configDone = false;
            do
            {
                //
                // Prompt user
                // Do we need to run BAT file or not
                LogService.Log.Info("Mapping finished. Do you wish to run the SQL mapping now? Y/N : ");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Y)
                {
                    LogService.Log.Info("Running SQL Migration script ...");
                    string filePath = manager.GetBATFilePath();


                    //
                    // Exec BAT file
                    filePath = Path.GetFullPath(filePath);
                    string folderPath = Path.GetDirectoryName(filePath);
                    try
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo();
                        processInfo.WorkingDirectory = folderPath;
                        processInfo.FileName = "cmd.exe";
                        processInfo.Arguments = @"/k " + filePath;
                        Process process = Process.Start(processInfo);
                    }
                    catch (Exception exc)
                    {
                        LogService.Log.Error("Can not run path file from this path : " + filePath, exc);
                    }
                    configDone = true;
                }
                else if (inputKey.Key == ConsoleKey.N)
                {
                    configDone = true;
                }
            } while (configDone == false);
        }
    }
}
