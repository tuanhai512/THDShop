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
    
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            this.BILL = new HashSet<BILL>();
        }
    
        public int ID { get; set; }
        public int IDUSER { get; set; }
        public string NAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public Nullable<System.DateTime> BRITHDAY { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string AVATAR { get; set; }
        public Nullable<int> IDROLES { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILL { get; set; }
        public virtual ROLES ROLES { get; set; }
        public virtual USERS USERS { get; set; }
    }
}
