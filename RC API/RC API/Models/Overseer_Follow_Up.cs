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
    
    public partial class Overseer_Follow_Up
    {
        public int OverseerFollowUpID { get; set; }
        public int PersonID { get; set; }
        public bool FollowUpStatus { get; set; }
        public int Structure { get; set; }
        public int ZonePastor { get; set; }
        public int Overseer { get; set; }
        public System.DateTime FollowUpDate { get; set; }
        public Nullable<bool> NoAnswer { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
