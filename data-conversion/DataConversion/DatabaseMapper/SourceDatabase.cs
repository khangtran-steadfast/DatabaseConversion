using AutoMapper;
using DataConversion.DatabaseMapper.MapperReport;
using DataConversion.DatabaseMapper.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FastMember;
using DataConversion.DatabaseMapper.BATFile;
namespace DataConversion.DatabaseMapper
{
    public abstract class SourceDatabase : MapDatabase
    {
        #region CONSTRUCTOR, INITIALIZE


        /// <summary>
        /// Create new source database
        /// </summary>
        /// <param name="dbContextType"></param>
        public SourceDatabase(Type dbContextType) : base(dbContextType)
        {

        }


        #endregion
    }
}
