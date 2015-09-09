using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseConversion.Common.Configurations
{
    public class TableMappingConfiguration
    {
        [XmlAttribute("SourceTable")]
        public string SourceTableName { get; set; }

        [XmlAttribute("DestinationTable")]
        public string DestinationTableName { get; set; }

        [XmlAttribute("ExcludeExistData")]
        public bool ExcludeExistData { get; set; }

        private List<FieldMappingConfiguration> _fieldMappings;
        [XmlArray("FieldMappings")]
        [XmlArrayItem("FieldMapping", typeof(FieldMappingConfiguration))]
        public List<FieldMappingConfiguration> FieldMappings
        {
            get { return _fieldMappings ?? (_fieldMappings = new List<FieldMappingConfiguration>()); }
            set { _fieldMappings = value; }
        }
    }
}
