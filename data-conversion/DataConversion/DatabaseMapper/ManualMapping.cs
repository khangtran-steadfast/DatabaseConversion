using DataConversion.DatabaseMapper.ErrorHandler;
using DataConversion.DatabaseMapper.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion.DatabaseMapper
{
    /// <summary>
    /// Abstract class provides the way to manual handle mapping process
    /// </summary>
    public abstract class ManualMapping
    {
        public static bool IgnoreBlobs;
        
        /// <summary>
        /// Create new Manual mapping for table
        /// </summary>
        /// <param name="ManualMappingAllProcess">If true, you have to override Map function to handle all mapping process. If false, system will take care about mapping process</param>
        public ManualMapping(bool ManualMappingAllProcess)
        {
            this._manualMappingAllProcess = ManualMappingAllProcess;
        }

        /// <summary>
        /// Main mapping function
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public virtual void Map(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
        }

        /// <summary>
        /// Function is invoked after mapping completed
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public virtual void AfterMapping(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase)
        {
        }

        /// <summary>
        /// Function is invoked after mapping single record completed
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="record"></param>
        public virtual void AfterMappingRecord(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object record)
        {
        }

        /// <summary>
        /// Function is invoked after commit changes
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public virtual void AfterCommitChanges(MappingManager manager,
                                               SourceDatabase sourceDatabase,
                                               DestinationDatabase destinationDatabase)
        {

        }

        /// <summary>
        /// Before running AutoMapper to map from old class to new class
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="record"></param>
        public virtual void BeforeRunningAutoMapper(MappingManager manager, 
                                                    SourceDatabase sourceDatabase,
                                                    DestinationDatabase destinationDatabase,
                                                    object record)
        {
        }

        /// <summary>
        /// Function is invoked before commit changes
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="listNewRecord"></param>
        public virtual void BeforeCommitChanges(MappingManager manager, 
                                                SourceDatabase sourceDatabase,
                                                DestinationDatabase destinationDatabase,
                                                List<object> listNewRecord)
        {

        }

        /// <summary>
        /// Function is invoked before mapping start
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        public virtual void BeforeMapping(MappingManager manager,
                                          SourceDatabase sourceDatabase,
                                          DestinationDatabase destinationDatabase)
        {
        }

        /// <summary>
        /// Function is invoked before mapping single record start
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="record"></param>
        public virtual void BeforeMappingRecord(MappingManager manager,
                                                SourceDatabase sourceDatabase,
                                                DestinationDatabase destinationDatabase,
                                                object record)
        {
        }

        /// <summary>
        /// Release memory
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        /// Is manual mapping all process ?
        /// </summary>
        public bool ManualMappingAllProcess
        {
            get
            {
                return this._manualMappingAllProcess;
            }
        }

        /// <summary>
        /// Flag to determinate this manual mapping will take care all mapping process or not
        /// </summary>
        protected bool _manualMappingAllProcess;
    }
}
