using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.Constants
{
    class BatTemplates
    {
        public const string DELETE_FILE = @"if exist ""{0}"" del ""{0}""";

        public const string CREATE_FOLDER = @"if not exist ""{0}"" mkdir ""{0}""";

        public const string ECHO_CONSOLE = @"echo {0}";

        public const string ECHO_FILE_APPEND = @"echo {0} >> {1}";

        public const string SQL_CMD = @"sqlcmd -S {ServerName}\{InstanceName} -i {ScriptPath} >> {OutputPath}";

        public const string BAT =
@"echo off

{0}
";
    }
}
