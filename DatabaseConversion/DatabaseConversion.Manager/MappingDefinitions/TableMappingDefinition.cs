﻿using DatabaseConversion.Common.Configurations;
using DatabaseConversion.Common.Exceptions;
using DatabaseConversion.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.MappingDefinitions
{
    class TableMappingDefinition
    {
        #region Fields

        private SourceTable _sourceTable;
        private DestinationTable _destinationTable;
        private List<FieldMappingDefinition> _fieldMappingDefinitions;

        #endregion

        #region Properties

        public SourceTable SourceTable
        {
            get { return _sourceTable; }
        }

        public DestinationTable DestinationTable
        {
            get { return _destinationTable; }
        }

        /// <summary>
        /// There is a problem with varchar(max) column in bcp when there is a mismatch between the number of varchar(max) columns 
        /// in datafile and target table. So we handle it seperately
        /// </summary>
        public bool HandleMaxTextSeperately 
        {
            get
            {
                var destFieldsCount = DestinationTable.Fields.Where(f => f.IsMaxDataType).Count();
                var mapFieldsCount = FieldMappingDefinitions.Where(d => d.DestinationField.IsMaxDataType).Count();

                return destFieldsCount != mapFieldsCount;
            }
        }

        public List<FieldMappingDefinition> FieldMappingDefinitions
        {
            get { return _fieldMappingDefinitions ?? (_fieldMappingDefinitions = new List<FieldMappingDefinition>()); }
        }

        #endregion

        public TableMappingDefinition(SourceTable sourceTable, DestinationTable destTable, List<FieldMappingConfiguration> explicitMappings = null)
        {
            _sourceTable = sourceTable;
            _destinationTable = destTable;
            bool hasExplicitMappings = explicitMappings != null;

            //_destinationTable.Fields.ForEach(f =>
            //{
            //    try
            //    {
            //        if (hasExplicitMappings)
            //        {
            //            var mappingConfig = explicitMappings.SingleOrDefault(m => m.DestinationFieldName.Equals(f.Name, StringComparison.InvariantCultureIgnoreCase));
            //            if (mappingConfig != null)
            //            {
            //                Field srcField = _sourceTable.GetField(mappingConfig.SourceFieldName);
            //                FieldMappingDefinitions.Add(new FieldMappingDefinition
            //                {
            //                    DestinationField = f,
            //                    SourceField = srcField,
            //                    Type = mappingConfig.Type,
            //                    BlobCategory = mappingConfig.BlobCategory,
            //                    ForceValue = mappingConfig.ForceValue,
            //                    GetBlobScriptPath = mappingConfig.GetBlobScriptPath
            //                });
            //            }
            //            else
            //            {
            //                Field srcField = _sourceTable.GetField(f.Name);
            //                FieldMappingDefinitions.Add(new FieldMappingDefinition
            //                {
            //                    DestinationField = f,
            //                    SourceField = srcField
            //                });
            //            }
            //        }
            //        else
            //        {
            //            Field srcField = _sourceTable.GetField(f.Name);
            //            FieldMappingDefinitions.Add(new FieldMappingDefinition
            //            {
            //                DestinationField = f,
            //                SourceField = srcField
            //            });
            //        }
            //    }
            //    catch (AppException ex)
            //    {
            //        if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_FIELD_NOT_FOUND)
            //        {
            //            // TODO: write log
            //            //Console.WriteLine(sourceTable.Name + " -> " + destinationTable.Name);
            //        }
            //    }
            //});

            sourceTable.Fields.ForEach(f =>
            {
                try
                {
                    if (hasExplicitMappings)
                    {
                        var mappingConfig = explicitMappings.SingleOrDefault(m => m.SourceFieldName.Equals(f.Name, StringComparison.InvariantCultureIgnoreCase));
                        if (mappingConfig != null)
                        {
                            if(!string.IsNullOrEmpty(mappingConfig.GetBlobScriptPath))
                            {
                                FieldMappingDefinitions.Add(new FieldMappingDefinition
                                {
                                    SourceField = new Field { Name = mappingConfig.SourceFieldName },
                                    DestinationField = new Field { Name = mappingConfig.DestinationFieldName },
                                    Type = mappingConfig.Type,
                                    BlobCategory = mappingConfig.BlobCategory,
                                    ForceValue = mappingConfig.ForceValue,
                                    GetBlobScriptPath = mappingConfig.GetBlobScriptPath
                                });
                            }
                            else
                            {
                                var destField = destTable.GetField(mappingConfig.DestinationFieldName);
                                if (destField != null)
                                {
                                    FieldMappingDefinitions.Add(new FieldMappingDefinition
                                    {
                                        SourceField = f,
                                        DestinationField = destField,
                                        Type = mappingConfig.Type,
                                        BlobCategory = mappingConfig.BlobCategory,
                                        ForceValue = mappingConfig.ForceValue,
                                    });
                                }
                            }
                        }
                        else
                        {
                            var destField = destTable.GetField(f.Name);
                            if(destField != null)
                            {
                                FieldMappingDefinitions.Add(new FieldMappingDefinition
                                {
                                    SourceField = f,
                                    DestinationField = destField
                                });
                            }
                        }
                    }
                    else
                    {
                        var destField = destTable.GetField(f.Name);
                        if(destField != null)
                        {
                            FieldMappingDefinitions.Add(new FieldMappingDefinition
                            {
                                SourceField = f,
                                DestinationField = destField
                            });
                        }
                    }
                }
                catch (AppException ex)
                {
                    if (ex.ErrorCode == AppExceptionCodes.DATABASE_ERROR_FIELD_NOT_FOUND)
                    {
                        // TODO: write log
                        //Console.WriteLine(sourceTable.Name + " -> " + destinationTable.Name);
                    }
                }
            });
        }
    }
}
