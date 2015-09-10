using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DatabaseConversion.Manager;
namespace DatabaseConversion.ConsoleApp
{
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Initialize for license aspose
            LicenseAspose();

            // Initialize
            string srcConnectionString = ConfigurationManager.ConnectionStrings["SourceDatabase"].ConnectionString;
            string destConnectionString = ConfigurationManager.ConnectionStrings["DestinationDatabase"].ConnectionString;
            ConversionOption options = LoadConfigurations();
            ConversionManager manager = new ConversionManager(srcConnectionString, destConnectionString, options);

            // Configure pre-conversion script and post-conversion script
            manager.AddPreConversionScript(@"SQLScript\3.2.2.AddNewField.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.3.CreatePolicyRecords.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.4.UpdatePoliciesTable.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.5.UpdateJournalsTable.sql");
            manager.AddPreConversionScript(@"SQLScript\3.2.6.UpdateWorkbook_NotesTable.sql");
            manager.AddPostConversionScript(@"SQLScript\3.2.7.PopulateCurrentPolicy.sql");
            manager.AddPostConversionScript(@"SQLScript\4.1.EntityBalance.sql");
            manager.AddPostConversionScript(@"SQLScript\4.2.PolicyBalance.sql");
            manager.AddPostConversionScript(@"SQLScript\4.3.PolicyInsured.sql");
            manager.AddPostConversionScript(@"SQLScript\4.5.AutoPolicyNumber.sql");
            manager.AddPostConversionScript(@"SQLScript\4.6.EditBrokerRepWorkbook.sql");
            manager.AddPostConversionScript(@"SQLScript\4.7.MandatoryFields.sql");

            // Start generate converesion package
            manager.Run();
        }

        /// <summary>
        /// Loading configuration from xml file
        /// </summary>
        /// <returns></returns>
        private static ConversionOption LoadConfigurations()
        {
            ConversionOption result = null;
            string path = "configurations.xml";

            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConversionOption));
                result = (ConversionOption)serializer.Deserialize(reader);
            }

            return result;
        }

        /// <summary>
        /// Load liencse for apose
        /// </summary>
        private static void LicenseAspose()
        {
            Aspose.Words.License word = new Aspose.Words.License();
            word.SetLicense("Aspose.Total.lic");

            Aspose.Cells.License excel = new Aspose.Cells.License();
            excel.SetLicense("Aspose.Total.lic");
        }
    }
}
