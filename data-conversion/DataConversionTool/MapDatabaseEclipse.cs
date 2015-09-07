using DataConversion.DatabaseMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataConversion
{
    class MapDatabaseEclipse : SourceDatabase
    {
        public MapDatabaseEclipse() : base(typeof(EclipseDataAccess.BOALedger_oldEntities))
        {
            this._dbContext = new EclipseDataAccess.BOALedger_oldEntities();
            this.Initialize();
        }

        protected override void ConfigManualMapping()
        {
            // this.AddManualMapping()
        }

        protected override void ConfigAutoMapperProfile(AutoMapper.Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
