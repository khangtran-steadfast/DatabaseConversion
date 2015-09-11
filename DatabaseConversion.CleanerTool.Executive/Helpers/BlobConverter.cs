using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Cells;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Providers.BlobStore;

namespace DatabaseConversion.CleanerTool.Executive.Helpers
{
    class BlobConverter
    {
        /// <summary>
        /// Converts binary to blob pointer
        /// </summary>
        /// <param name="category">The file category.</param>
        /// <param name="data">The data.</param>
        /// <param name="name">The name.</param>
        /// <returns>Blob Pointer</returns>
        public static string ConvertToFile(string category, string name, byte[] data)
        {
            if (data == null)
            { 
                return null; 
            }

            using (Stream stream = new MemoryStream(data))
            {
                // convert doc, xls -> docx, xlsx
                Stream streamToSave = new MemoryStream();
                if (FileTypeDetector.IsDoc(data))
                {
                    Document doc = new Document(stream);
                    doc.RemoveMacros();
                    doc.Save(streamToSave, Aspose.Words.SaveFormat.Docx);
                }
                else if (FileTypeDetector.IsXls(data))
                {
                    Workbook xls = new Workbook(stream);
                    xls.RemoveMacro();
                    xls.Save(streamToSave, Aspose.Cells.SaveFormat.Xlsx);
                }
                else
                {
                    streamToSave = stream;
                }

                // save to file
                streamToSave.Position = 0;
                string result = BlobStoreProvider.Instance.PutBlob(category, name, streamToSave);

                return result;
            }
        }

        /// <summary>
        /// Converts binary to string.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>String content</returns>
        public static string ConvertToString(byte[] data)
        {
            if (data == null)
            { 
                return null; 
            }
            return Encoding.ASCII.GetString(data, 0, data.Length);
        }
    }
}
