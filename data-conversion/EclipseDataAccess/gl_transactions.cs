//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EclipseDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class gl_transactions
    {
        public int gltr_id { get; set; }
        public System.DateTime gltr_date { get; set; }
        public int gltr_glmv_id { get; set; }
        public int gltr_glsl_id { get; set; }
        public decimal gltr_amount { get; set; }
        public string gltr_created_who { get; set; }
        public Nullable<System.DateTime> gltr_created_when { get; set; }
        public string gltr_updated_who { get; set; }
        public Nullable<System.DateTime> gltr_updated_when { get; set; }
    
        public virtual gl_movements gl_movements { get; set; }
    }
}
