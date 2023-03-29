namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RestTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestTable()
        {
            BookingTables = new HashSet<BookingTable>();
        }

        public int Id { get; set; }

        public int TableNumber { get; set; }

        public int? PositionId { get; set; }

        [Required]
        public string Comment { get; set; }

        public bool IsActive { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingTable> BookingTables { get; set; }

        public virtual TablePosition TablePosition { get; set; }

        public virtual User User { get; set; }
    }
}
