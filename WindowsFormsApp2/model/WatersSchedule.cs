namespace WindowsFormsApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WatersSchedule")]
    public partial class WatersSchedule
    {
        public int Id { get; set; }

        public int WaterId { get; set; }

        [Column(TypeName = "date")]
        public DateTime WorkDate { get; set; }

        public int ChangedBy { get; set; }

        public DateTime ChangedDate { get; set; }

        public virtual User User { get; set; }
    }
}
