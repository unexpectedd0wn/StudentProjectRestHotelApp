namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            BanquetDishes = new HashSet<BanquetDish>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public int? Type { get; set; }

        public decimal Weight { get; set; }

        public bool IsAvalible { get; set; }

        public string Сomposition { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime? ChangedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanquetDish> BanquetDishes { get; set; }

        public virtual DishType DishType { get; set; }
    }
}
