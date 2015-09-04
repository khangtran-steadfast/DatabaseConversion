using DatabaseConversion.Common.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseConversion.Manager
{
    [XmlRoot("Configurations")]
    public class MigrationOptions
    {
        [XmlElement]
        public string ServerName { get; set; }

        [XmlElement]
        public string InstanceName { get; set; }

        [XmlElement]
        public string Username { get; set; }

        [XmlElement]
        public string Password { get; set; }

        [XmlArray("ExplicitTableMappings")]
        [XmlArrayItem("TableMapping", typeof(TableMappingConfiguration))]
        public List<TableMappingConfiguration> ExplicitTableMappings { get; set; }
    }
}
