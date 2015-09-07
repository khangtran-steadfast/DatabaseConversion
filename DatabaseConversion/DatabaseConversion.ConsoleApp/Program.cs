using DatabaseConversion.Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseConversion.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LicenseAspose();

            string srcConnectionString = ConfigurationManager.ConnectionStrings["SourceDatabase"].ConnectionString;
            string destConnectionString = ConfigurationManager.ConnectionStrings["DestinationDatabase"].ConnectionString;
            ConversionOption options = LoadConfigurations();
            ConversionManager manager = new ConversionManager(srcConnectionString, destConnectionString, options);
            manager.GenerateConversionPackage();
        }

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

        private static void LicenseAspose()
        {
            Aspose.Words.License word = new Aspose.Words.License();
            word.SetLicense("Aspose.Total.lic");

            Aspose.Cells.License excel = new Aspose.Cells.License();
            excel.SetLicense("Aspose.Total.lic");
        }
    }
}
