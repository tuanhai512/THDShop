//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Manager
{
    using System;
    using System.Collections.Generic;
    
    public partial class DELI_ADDRESS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DELI_ADDRESS()
        {
            this.ORDERS = new HashSet<ORDER>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDCUSTOMER { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string WARD { get; set; }
        public string DISTRICT { get; set; }
        public string NOTE { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
