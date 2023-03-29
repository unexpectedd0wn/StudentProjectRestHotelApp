namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Banquet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Banquet()
        {
            BanquetDishes = new HashSet<BanquetDish>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Time { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [StringLength(50)]
        public string NumberOfQuests { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerFirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerPhoneNumber { get; set; }

        public int PrepaymentId { get; set; }

        public int StatusId { get; set; }

        public decimal Service { get; set; }

        public decimal Discount { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangeDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanquetDish> BanquetDishes { get; set; }

        public virtual BanquetStatu BanquetStatu { get; set; }

        public virtual PrepaymentStatus PrepaymentStatus { get; set; }

        public virtual User User { get; set; }
    }
}
