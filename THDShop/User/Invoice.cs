//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace User
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int ID { get; set; }
        public int OrderId { get; set; }
        public Nullable<int> Methods { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> TotalMoney { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateAt { get; set; }
    
        public virtual Orders Orders { get; set; }
    }
}