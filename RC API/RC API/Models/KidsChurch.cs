//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RC_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KidsChurch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KidsChurch()
        {
            this.Person_Children = new HashSet<Person_Children>();
        }
    
        public int KidsChurchID { get; set; }
        public string KidsChurchName { get; set; }
        public string HeadOfChurch { get; set; }
        public string QRcode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person_Children> Person_Children { get; set; }
    }
}
