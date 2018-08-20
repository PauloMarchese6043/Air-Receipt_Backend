using System.Data.Entity;

namespace WebServer.Models.DbTables
{
    public class DatabaseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DatabaseContext() : base("name=DataBaseContext")
        {
        }

        public DbSet<DEVICES> DEVICES { get; set; }

        public DbSet<DEVICE_USES> DEVICE_USES { get; set; }

        public DbSet<RECEIPTS> RECEIPTS { get; set; }

        public DbSet<STORES> STORES { get; set; }

        public DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RECEIPTS>().HasRequired(x => x.STORE).WithMany().WillCascadeOnDelete(false);
        }
    }
}