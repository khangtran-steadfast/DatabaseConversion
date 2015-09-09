using DatabaseConversion.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseConversion.Common.Configurations
{
    public class FieldMappingConfiguration
    {
        [XmlAttribute("SourceField")]
        public string SourceFieldName { get; set; }

        [XmlAttribute("DestinationField")]
        public string DestinationFieldName { get; set; }

        [XmlAttribute]
        public FieldMappingType Type { get; set; }

        [XmlAttribute]
        public string BlobCategory { get; set; }

        [XmlAttribute]
        public string ForceValue { get; set; }
    }
}
