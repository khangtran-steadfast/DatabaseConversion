using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Base.DatabaseMapper.DataValidation
{
    /// <summary>
    /// Abstract class provides the way to validate data
    /// </summary>
    public abstract class RecordValidation
    {
        /// <summary>
        /// Validate database
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="mapDatabase"></param>
        public abstract void Validate(MappingManager manager, MapDatabase mapDatabase);

        /// <summary>
        /// Validate data use source database and destination database
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public abstract void Validate(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase);
    }
}
