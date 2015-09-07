using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.Constants
{
    class BcpTemplates
    {
        public const string BCP_EXPORT = @"bcp ""{Query}"" queryout {OutputPath} -S {ServerName}\{InstanceName} -T -f {FormatFilePath} >> {LogPath}";

        public const string BCP_IMPORT = @"bcp {TableFullName} in {DataFilePath} -S {ServerName}\{InstanceName} -E -T -f {FormatFilePath} -e Error_Log.txt>> {LogPath}";

        public const string BCP_FORMAT_FILE =
@"10.0
{FieldCount}
{Fields}
";

        public const string BCP_FORMAT_ROW =
@"{Index}       {DataType}            {PrefixLength}       {Length}     """"      {ServerColumnOrder}     {ServerColumnName}         {Collation}";

//        public const string BCP_FORMAT_LAST_ROW =
//@"{Index}       SQLCHAR            0       0     ""\r\n###\r\n""   {ServerColumnOrder}     {ServerColumnName}         SQL_Latin1_General_CP1_CI_AS";
    }
}
