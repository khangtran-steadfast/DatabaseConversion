using DatabaseConversion.DatabaseAccess;
using DatabaseConversion.Manager.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringInject;
using System.IO;

namespace DatabaseConversion.Manager.Generators
{
    class BatGenerator
    {
        public static string GenerateSqlExecuteScript(List<string> scriptNames, string serverName, string instanceName, string outputPath)
        {
            StringBuilder batBuilder = new StringBuilder();

            batBuilder.AppendLine(string.Format(BatTemplates.DELETE_FILE, @"SQL_LOG.txt"));

            for (int i = 0; i < scriptNames.Count; i++)
            {
                string scriptName = scriptNames[i];

                string scriptPath = Path.Combine(Path.GetFullPath(outputPath), scriptName);
                batBuilder.AppendLine(string.Format(BatTemplates.ECHO_CONSOLE, scriptName));
                batBuilder.AppendLine(string.Format(BatTemplates.ECHO_FILE_APPEND, scriptName, @"SQL_LOG.txt"));
                batBuilder.AppendLine(BatTemplates.SQL_CMD.Inject(new
                {
                    ServerName = serverName,
                    InstanceName = instanceName,
                    ScriptPath = scriptName,
                    OutputPath = @"SQL_LOG.txt"
                }));
            }

            string content = string.Format(BatTemplates.BAT, batBuilder.ToString());
            return content;
        }

        public static string GenerateBcpExecuteScript(Dictionary<string, string> bcpCommands)
        {
            StringBuilder batBuilder = new StringBuilder();

            batBuilder.AppendLine(string.Format(BatTemplates.DELETE_FILE, @"BCP_LOG.txt"));

            foreach (var command in bcpCommands)
            {
                batBuilder.AppendLine(string.Format(BatTemplates.ECHO_CONSOLE, command.Key));
                batBuilder.AppendLine(string.Format(BatTemplates.ECHO_FILE_APPEND, command.Key, @"BCP_LOG.txt"));
                batBuilder.AppendLine(command.Value);
            }

            string content = string.Format(BatTemplates.BAT, batBuilder.ToString());
            return content;
        }
    }
}
