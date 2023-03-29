using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WindowsFormsApp2.model
{
    public partial class DBEntity : DbContext
    {
        public DBEntity()
            : base("name=DBEntity")
        {
        }

        public virtual DbSet<BanquetDish> BanquetDishes { get; set; }
        public virtual DbSet<Banquet> Banquets { get; set; }
        public virtual DbSet<BanquetStatu> BanquetStatus { get; set; }
        public virtual DbSet<BookingTable> BookingTables { get; set; }
        public virtual DbSet<BookingTableStatu> BookingTableStatus { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishType> DishTypes { get; set; }
        public virtual DbSet<PrepaymentStatus> PrepaymentStatuses { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<RestTable> RestTables { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TablePosition> TablePositions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Waiter> Waiters { get; set; }
        public virtual DbSet<WatersSchedule> WatersSchedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banquet>()
                .Property(e => e.Time)
                .IsUnicode(false);

            modelBuilder.Entity<Banquet>()
                .Property(e => e.Service)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Banquet>()
                .Property(e => e.Discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<BanquetStatu>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<BanquetStatu>()
                .HasMany(e => e.Banquets)
                .WithRequired(e => e.BanquetStatu)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookingTable>()
                .Property(e => e.BookingTime)
                .IsUnicode(false);

            modelBuilder.Entity<BookingTableStatu>()
                .HasMany(e => e.BookingTables)
                .WithRequired(e => e.BookingTableStatu)
                .HasForeignKey(e => e.StatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Price)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Discount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Weight)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Dish>()
                .HasMany(e => e.BanquetDishes)
                .WithRequired(e => e.Dish)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DishType>()
                .HasMany(e => e.Dishes)
                .WithOptional(e => e.DishType)
                .HasForeignKey(e => e.Type);

            modelBuilder.Entity<PrepaymentStatus>()
                .HasMany(e => e.Banquets)
                .WithRequired(e => e.PrepaymentStatus)
                .HasForeignKey(e => e.PrepaymentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RestTable>()
                .HasMany(e => e.BookingTables)
                .WithRequired(e => e.RestTable)
                .HasForeignKey(e => e.Table)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablePosition>()
                .HasMany(e => e.RestTables)
                .WithOptional(e => e.TablePosition)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BanquetDishes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ChangedBy);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Banquets)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BookingTables)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.DishTypes)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PrepaymentStatuses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reports)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RestTables)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TablePositions)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Waiters)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.WatersSchedules)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChangedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
