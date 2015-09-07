using DataConversion.DatabaseMapper;
using DataConversion.DatabaseMapper.Information;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool
{
    class Utils
    {
        public static void Task_GetRelatedTable(string tableName, string fileOutput)
        {
            BOALedgerDatabase database = new BOALedgerDatabase();
            MapTable table = database.GetMapTable(tableName);
            List<string> hasChecked = new List<string>();
            hasChecked.Add(tableName);
            Task_GetRelatedTableRecursion(database, tableName, hasChecked);

            StreamWriter writer = new StreamWriter(fileOutput);
            foreach (string str in hasChecked)
            {
                writer.WriteLine(str);
                Console.WriteLine(str);
            }
            writer.Close();
        }

        public static void Task_GetRelatedTableRecursion(BOALedgerDatabase database, string tableName, List<string> hasChecked)
        {
            MapTable table = database.GetMapTable(tableName);
            foreach (ReferenceInformation reference in table.GetReference())
            {
                if (hasChecked.Contains(reference.PKTableName) == false)
                {
                    hasChecked.Add(reference.PKTableName);
                    Task_GetRelatedTableRecursion(database, reference.PKTableName, hasChecked);
                }
                else
                {

                }
            }
        }
    }
}
