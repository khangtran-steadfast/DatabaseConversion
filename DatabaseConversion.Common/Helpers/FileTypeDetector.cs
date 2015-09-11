using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Common.Helpers
{
    public class FileTypeDetector
    {
        /// <summary>
        /// Base 8 bytes header for Doc/Xls
        /// </summary>
        private const string HEADER_BASE_BYTES = "D0 CF 11 E0 A1 B1 1A E1";

        private const string SUBHEADER_DOC_BYTES = "EC A5 C1 00";

        private const string SUBHEADER_XLS_BYTES = "09 08 10 00 00 06 05 00";

        public static bool IsDoc(byte[] data)
        {
            if (data == null || !data.Any())
            {
                return false;
            }

            return BytesToString(data.Take(8)).Equals(HEADER_BASE_BYTES) && BytesToString(data.Skip(512).Take(4)).Equals(SUBHEADER_DOC_BYTES);
        }

        public static bool IsXls(byte[] data)
        {
            if (data == null || !data.Any())
            {
                return false;
            }

            return BytesToString(data.Take(8)).Equals(HEADER_BASE_BYTES) && BytesToString(data.Skip(512).Take(8)).Equals(SUBHEADER_XLS_BYTES);
        }

        private static string BytesToString(IEnumerable<byte> data)
        {
            return data.Select(x => x.ToString("X2")).Aggregate((x, y) => x + " " + y);
        }
    }
}
