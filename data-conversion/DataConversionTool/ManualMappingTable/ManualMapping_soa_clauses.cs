using DataConversion;
using DataConversion.DatabaseMapper;
using DocumentGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversionTool.ManualMappingTable
{
    class ManualMapping_soa_clauses : ManualMapping
    {
        /// <summary>
        /// Create manual mapping for statements table
        /// This class will take care all mapping process
        /// </summary>
        public ManualMapping_soa_clauses()
            : base(false)
        {

        }

        /// <summary>
        /// Change format before running automapper
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="sourceDatabase"></param>
        /// <param name="destinationDatabase"></param>
        /// <param name="obj"></param>
        public override void BeforeRunningAutoMapper(MappingManager manager, SourceDatabase sourceDatabase, DestinationDatabase destinationDatabase, object obj)
        {
            //
            // Try to cast type first
            EclipseDataAccess.soa_clauses record = null;
            try
            {
                record = obj as EclipseDataAccess.soa_clauses;
            }
            catch (Exception excCastType)
            {
                LogService.Log.Error("Can not cast type as soa_clauses.", excCastType);
                return;
            }


            //
            // Change from rtf format to html format
            if (record.nature_of_advice != null)
            {
                record.nature_of_advice = WordGenerator.ConvertRtfToHtml(record.nature_of_advice);
            }
            if (record.recommendations != null)
            {
                record.recommendations = WordGenerator.ConvertRtfToHtml(record.recommendations);
            }
            if (record.optional_notice1 != null)
            {
                record.optional_notice1 = WordGenerator.ConvertRtfToHtml(record.optional_notice1);
            }
            if (record.optional_notice2 != null)
            {
                record.optional_notice2 = WordGenerator.ConvertRtfToHtml(record.optional_notice2);
            }
            if (record.optional_notice3 != null)
            {
                record.optional_notice3 = WordGenerator.ConvertRtfToHtml(record.optional_notice3);
            }
        }
    }
}
