using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DatabaseMapper;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DataValidation;
using DatabaseConversion.CleanerTool.Base.DatabaseMapper.DataValidation.Orphan;
using DataConversionTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConversion.CleanerTool.Executive
{
    public class Cleaner
    {
        public static void CleanSourceDatabase()
        {
            EclipseDatabase source = new EclipseDatabase();
            BOALedgerDatabase destination = new BOALedgerDatabase();
            MappingManager manager = new MappingManager(source, destination);
            ValidationManager validationManager = new ValidationManager();
            validationManager.Validate<OrphanRecordValidation>(manager, source, destination);
        }
    }
}
