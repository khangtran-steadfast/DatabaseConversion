using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.BATFile
{
    /// <summary>
    /// Class generates bat file to execute SQL script or command
    /// </summary>
    public class SQLBATGenerator : BATFileGenerator
    {
        /// <summary>
        /// Create generator to generate bat file, execute SQL script or command
        /// </summary>
        /// <param name="filePath"></param>
        public SQLBATGenerator(string filePath) : base(filePath)
        {
            this._serverVariableName = "server";
            this._serverVariableHolder = "%server%";
        }

        /// <summary>
        /// Prompt user for sever name
        /// </summary>
        public void PromptServerName()
        {
            this.ShowMessage(@"Please enter server name, example : .\sqlexpress");
            this.PromptInput(this._serverVariableName, "Server name : ");
        }

        /// <summary>
        /// Generate bat command to run sql script from file
        /// </summary>
        /// <param name="filePath">SQL Script's file path</param>
        public void RunSQLFile(string filePath)
        {
            //
            // Get file name
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string OUTPUT_FILE ="error.txt";

            //
            // Generate command
            string command = "sqlcmd -S {SERVER_NAME_HOLDER} -i {SQL_SCRIPT_PATH} -r1 2>> {OUTPUT_FILE}";
            this.NewLine();

            //
            // Write message to output file
            this.Append("--------------------------------------", OUTPUT_FILE);
            this.Append("Run " + fileName, OUTPUT_FILE);
            this.ShowMessage("Run sql script " + filePath);

            //
            // Run sql script
            this.Append(command.Replace("{SERVER_NAME_HOLDER}", this._serverVariableHolder)
                               .Replace("{SQL_SCRIPT_PATH}", filePath)
                               .Replace("{OUTPUT_FILE}", OUTPUT_FILE));
        }
        
        /// <summary>
        /// Server vaiable name
        /// </summary>
        private string _serverVariableName;

        /// <summary>
        /// Place holder for server name
        /// </summary>
        private string _serverVariableHolder;
    }
}
