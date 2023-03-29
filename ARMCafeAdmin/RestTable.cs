//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARMCafeAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestTable()
        {
            this.BookingTables = new HashSet<BookingTable>();
        }
    
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public Nullable<int> PositionId { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public int ChangedBy { get; set; }
        public System.DateTime ChangedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingTable> BookingTables { get; set; }
        public virtual TablePosition TablePosition { get; set; }
        public virtual User User { get; set; }
    }
}