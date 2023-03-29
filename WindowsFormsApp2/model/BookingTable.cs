namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingTable
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int Table { get; set; }

        [Required]
        [StringLength(50)]
        public string NumberOfQuests { get; set; }

        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string BookingTime { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangedDate { get; set; }

        public virtual BookingTableStatu BookingTableStatu { get; set; }

        public virtual RestTable RestTable { get; set; }

        public virtual User User { get; set; }
    }
}
