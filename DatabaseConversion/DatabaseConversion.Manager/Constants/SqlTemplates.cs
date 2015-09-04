using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.Constants
{
    class SqlTemplates
    {
        public const string SELECT = "SELECT {Fields} FROM {TableFullName}";

        public const string CREATE_TEMP_TABLE =
@"CREATE TABLE #Temp
(
	Id int,
	{0}
)";

        public const string DECLARE_FIELD_VARCHAR_MAX = @"{0} varchar(MAX)";

        public const string INSERT = @"INSERT {0} ({1})";
        public const string INSERT_VALUES = @"VALUES {0}";
        public const string FIELD = "[{0}]";
        public const string FIELD_NULL_DEFAULT_VALUE = @"ISNULL([{FieldName}],{Value})";
    }
}
