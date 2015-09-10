using DatabaseConversion.Common.Enums;
using DatabaseConversion.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.Manager.MappingDefinitions
{
    public class FieldMappingDefinition
    {
        public Field SourceField { get; set; }

        public Field DestinationField { get; set; }

        public FieldMappingType Type { get; set; }

        public string BlobCategory { get; set; }

        public string ForceValue { get; set; }

        public string GetBlobScriptPath { get; set; }
    }
}
