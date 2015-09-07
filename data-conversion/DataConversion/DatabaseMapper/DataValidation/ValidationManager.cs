using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper.DataValidation
{
    public class ValidationManager
    {
        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="recordValidation"></param>
        /// <param name="manager"></param>
        /// <param name="database"></param>
        public void Validate<T>(MappingManager manager, MapDatabase database) where T : RecordValidation, new()
        {
            T validator = new T();
            validator.Validate(manager, database);
        }

        /// <summary>
        /// Validate data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public void Validate<T>(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase) where T : RecordValidation, new()
        {
            T validator = new T();
            validator.Validate(manager, sourceDatabase, destinationDatabase);
        }
    }
}
