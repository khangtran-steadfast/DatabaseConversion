using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.BATFile
{
    /// <summary>
    /// Generate BAT file
    /// </summary>
    public class BATFileGenerator
    {
        /// <summary>
        /// Create new BATFileGenerator
        /// </summary>
        /// <param name="filePath">BAT file's path</param>
        public BATFileGenerator(string filePath)
        {
            //
            // Check file exist or not
            // If file exist
            // Delete file
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception exc)
                {
                    LogService.Log.Error("Can not delete file, file path : " + filePath, exc);
                }
            }
            this._filePath = filePath;
        }

        /// <summary>
        /// Append text to BAT file
        /// </summary>
        /// <param name="text"></param>
        public void Append(string text)
        {
            try
            {
                StreamWriter writer = new StreamWriter(this._filePath, true);
                writer.WriteLine(text);
                writer.Close();
            }
            catch (Exception excOpenStream)
            {
                LogService.Log.Error("Can not open stream writer to write.", excOpenStream);
            }
        }

        /// <summary>
        /// Append text to file
        /// </summary>
        /// <param name="text"></param>
        /// <param name="filePath"></param>
        public void Append(string text, string filePath)
        {
            this.Append("@echo " + text + " >> " + filePath);
        }

        /// <summary>
        /// Generate batch script to append source file to destination file
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public void Concat(string source, string destination)
        {
            this.Append("@more " + source + " >> " + destination);
        }

        /// <summary>
        /// Append comment to batch file
        /// </summary>
        /// <param name="comment"></param>
        public void Comment(string comment)
        {
            string command = ":: " + comment;
            this.Append(comment);
        }

        /// <summary>
        /// Open file by file path
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenFile(string filePath)
        {
            this.Append(filePath);
        }

        /// <summary>
        /// Echo on
        /// </summary>
        public void EchoOn()
        {
            this.Append("@echo on");
        }

        /// <summary>
        /// Echo off
        /// </summary>
        public void EchoOff()
        {
            this.Append("@echo off");
        }

        /// <summary>
        /// Jump to new line
        /// </summary>
        public void NewLine()
        {
            this.Append(Environment.NewLine);
        }

        /// <summary>
        /// Append message
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            string command = "@echo " + message;
            this.Append(command);
        }

        /// <summary>
        /// Read and write out file's contain
        /// </summary>
        /// <param name="filePath"></param>
        public void ShowFile(string filePath)
        {
            this.Append("type " + filePath);
        }

        /// <summary>
        /// Prompt user for input
        /// </summary>
        /// <param name="variableName"></param>
        /// <returns></returns>
        public void PromptInput(string variableName)
        {
            string command = "@set /p " + variableName + "=";
            this.Append(command);
        }

        /// <summary>
        /// Prompt user for input
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="message"></param>
        public void PromptInput(string variableName, string message)
        {
            string command = "@set /p {VARIABLE_NAME}=\"{MESSAGE}\"";
            this.Append(command.Replace("{VARIABLE_NAME}", variableName)
                               .Replace("{MESSAGE}", message));
        }

        /// <summary>
        /// Get file path to BAT File
        /// </summary>
        public string FilePath
        {
            get
            {
                return this._filePath;
            }
        }

        /// <summary>
        /// BAT file's path
        /// </summary>
        private string _filePath;
    }
}
