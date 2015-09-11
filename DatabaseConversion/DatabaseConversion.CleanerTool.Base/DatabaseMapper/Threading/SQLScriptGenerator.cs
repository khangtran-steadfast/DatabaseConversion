using DatabaseConversion.CleanerTool.Base.DatabaseMapper.Information;
using FastMember;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.Threading
{
    /// <summary>
    /// Generate SQL script to insert new data to database
    /// </summary>
    public class SQLScriptGenerator
    {
        #region CONSTRUCTOR


        /// <summary>
        /// Create new SQL Script generetor
        /// </summary>
        /// <param name="tableName">Table name to insert data</param>
        /// <param name="typeAccessor">TypeAccessor to access record value</param>
        /// <param name="listColumnName">List column name</param>
        /// <param name="listColumnType">List column type</param>
        public SQLScriptGenerator(string tableName, TypeAccessor typeAccessor, List<ColumnInformation> listColumnInformation)
        {
            //
            // Set control value
            this._tableName = tableName;
            this._typeAccessor = typeAccessor;
            this._listColumnInformation = listColumnInformation;


            //
            // Set value for insert template
            this.UpdateTableNameToTemplate(tableName);
            this.UpdateListColumnToTemplate(listColumnInformation);
        }


        #endregion


        #region METHODS


        /// <summary>
        /// Update table name to template
        /// </summary>
        /// <param name="tableName"></param>
        private void UpdateTableNameToTemplate(string tableName)
        {
            this.INSERT_TEMPLATE = this.INSERT_TEMPLATE.Replace(TABLE_NAME_PLACEHOLDER, tableName);
        }

        /// <summary>
        /// Update list column for insert template
        /// </summary>
        /// <param name="listColumnName">List contains column's name</param>
        private void UpdateListColumnToTemplate(List<ColumnInformation> listColumnInformation)
        {
            string LIST_COLUMN = "";
            bool first = true;
            foreach (ColumnInformation columnInformation in listColumnInformation)
            {
                if (first)
                {
                    LIST_COLUMN = "[" + columnInformation.ColumnName + "]";
                    first = false;
                }
                else
                {
                    LIST_COLUMN = LIST_COLUMN + ", " + "[" + columnInformation.ColumnName + "]";
                }
            }
            this.INSERT_TEMPLATE = this.INSERT_TEMPLATE.Replace(LIST_COLUMN_PLACEHOLDER, LIST_COLUMN);
        }

        /// <summary>
        /// Get sql insert script for value
        /// </summary>
        /// <param name="value">Value needs to be converted</param>
        /// <returns></returns>
        private string GenerateInsertScriptForValue(object value, string sqlType)
        {
            //
            // Initialize result
            string result = "NULL";
            sqlType = sqlType.ToLower();

            //
            // Check type of result
            // For each type, we will have different insert script
            if (value == null)
            {
                result = "NULL";
                return result;
            }

            //
            // If sqlType is smalldatetime
            if (sqlType.Equals("smalldatetime"))
            {
                DateTime dt = (DateTime)value;
                result = "CAST('" + dt.ToString("yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture) + "' AS smalldatetime)";
                return result;
            }

            //
            // If sqlType is datetime
            if (sqlType.Equals("datetime"))
            {
                DateTime dt = (DateTime)value;
                result = "CAST('" + dt.ToString("yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture) + "' AS datetime)";
                return result;
            }

            //
            // If sqlType is timestamp
            // We will set result to IGNORE
            if (sqlType.Equals("timestamp"))
            {
                result = "DEFAULT";
                return result;
            }

            //
            // Boolean type
            if (value is Boolean)
            {
                Nullable<Boolean> boolValue = value as Nullable<Boolean>;
                result = boolValue.Value ? "1" : "0";
                return result;
            }


            //
            // String type
            if (value is String)
            {
                String strValue = value as String;
                strValue = strValue.Replace("'", "''");
                result = "'" + strValue + "'";
                return result.Replace("\\\\", "\\");
            }


            //
            // DateTime type
            if (value is DateTime)
            {
                String strValue = value.ToString();
                result = "'" + strValue + "'";
                return result;
            }


            //
            // Byte[] type
            if (value is byte[])
            {
                byte[] byteArray = value as byte[];
                result = "0x" + BitConverter.ToString(byteArray).Replace("-", String.Empty);
                return result;
            }


            //
            // Default is numeric type
            result = value.ToString();


            //
            // Return result
            return result;
        }

        /// <summary>
        /// Generate insert script to insert new record
        /// </summary>
        /// <param name="record">Record needs to be inserted</param>
        /// <returns></returns>
        public string GenerateInsertScript(object record)
        {
            //
            // Initialize result
            string result = INSERT_TEMPLATE;
            string LIST_VALUE = "";


            //
            // Try to get value from record and extract to sql script
            bool first = true;
            foreach (ColumnInformation columnInformation in this._listColumnInformation)
            {
                if (first)
                {
                    LIST_VALUE = this.GenerateInsertScriptForValue(this._typeAccessor[record, columnInformation.ColumnName], columnInformation.DataType);
                    first = false;
                }
                else
                {
                    LIST_VALUE = LIST_VALUE + ", " + this.GenerateInsertScriptForValue(this._typeAccessor[record, columnInformation.ColumnName], columnInformation.DataType);
                }
            }


            //
            // Return result
            result = result.Replace(LIST_VALUE_PLACEHOLDER, LIST_VALUE);
            return result;
        }


        #endregion


        #region MEMBER, PROPERTIES


        /// <summary>
        /// Insert template
        /// </summary>
        protected string INSERT_TEMPLATE = @"INSERT INTO dbo.{TABLE_NAME}({LIST_COLUMN}) VALUES({LIST_VALUE})";

        /// <summary>
        /// Table name place holder
        /// </summary>
        protected static string TABLE_NAME_PLACEHOLDER = "{TABLE_NAME}";

        /// <summary>
        /// List column place holder
        /// </summary>
        protected static string LIST_COLUMN_PLACEHOLDER = "{LIST_COLUMN}";

        /// <summary>
        /// List value place holder
        /// </summary>
        protected static string LIST_VALUE_PLACEHOLDER = "{LIST_VALUE}";

        /// <summary>
        /// List column information
        /// </summary>
        protected List<ColumnInformation> _listColumnInformation;

        /// <summary>
        /// Table name
        /// </summary>
        protected string _tableName;

        /// <summary>
        /// Type accessor
        /// </summary>
        protected TypeAccessor _typeAccessor;


        #endregion
    }
}
