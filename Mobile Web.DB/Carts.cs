//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobile_Web.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carts
    {
        public int C_id { get; set; }
        public Nullable<int> U_id { get; set; }
        public Nullable<int> P_id { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
