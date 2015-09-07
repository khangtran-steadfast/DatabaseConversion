using AutoMapper;
using DataConversion.DatabaseMapper;
using DataConversion.LogService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace DataConversion
{
    class MapDatabaseBOALedger : MapDatabase
    {
        public MapDatabaseBOALedger() : base(typeof(BOALedgerDataAccess.BOALedgerEntities))
        {
            this._dbContext = new BOALedgerDataAccess.BOALedgerEntities();
            this.Initialize();
            
            //
            // Remove table don't have primary key (can not add to EMDX file)
            //this.RemoveTable("ageing_debtors_v");
            //this.RemoveTable("statements");
            //this.RemoveTable("tmpPortfolioAnalysis");
            //this.RemoveTable("turnover");
            //this.RemoveTable("view_DofiReport_Table1");
            //this.RemoveTable("view_earnings");
            //this.RemoveTable("view_earnings2");
            //this.RemoveTable("view_inspay");
            //this.RemoveTable("vims_EarningsDiff");
            //this.RemoveTable("atura_audit");
            //this.RemoveTable("Cash_Receipt_Lock");
            //this.RemoveTable("glsl_Transactions");
            //this.RemoveTable("IBA");
            //this.RemoveTable("period_renewals_particulars_t");
            //this.RemoveTable("renewal_retention_report");
            //this.RemoveTable("expiry_register_particulars_t");
            //this.RemoveTable("vims_unallocated_csh_credits");
            //this.RemoveTable("systemdiagram");
        }
    }
}
