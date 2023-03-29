namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BanquetDish
    {
        public int Id { get; set; }

        public int BanquetId { get; set; }

        public int DishId { get; set; }

        public int? Qty { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime? ChangedDate { get; set; }

        public virtual Banquet Banquet { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual User User { get; set; }
    }
}
