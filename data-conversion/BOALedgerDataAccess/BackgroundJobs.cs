//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOALedgerDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class BackgroundJobs
    {
        public int bj_id { get; set; }
        public string bj_job_name { get; set; }
        public string bj_started_by { get; set; }
        public Nullable<System.DateTime> bj_start_time { get; set; }
        public Nullable<System.DateTime> bj_end_time { get; set; }
        public string bj_log { get; set; }
        public string bj_status { get; set; }
        public string bj_server { get; set; }
        public string bj_result { get; set; }
        public Nullable<int> bj_total_steps { get; set; }
        public Nullable<int> bj_steps_completed { get; set; }
        public byte[] RowVersion { get; set; }
        public string bj_current_step_description { get; set; }
    }
}
