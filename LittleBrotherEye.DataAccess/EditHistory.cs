//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LittleBrotherEye.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class EditHistory
    {
        public int HistoryId { get; set; }
        public int EventId { get; set; }
        public System.DateTime EditDate { get; set; }
        public string NewName { get; set; }
        public string IpAdress { get; set; }
    
        public virtual Event Event { get; set; }
    }
}
