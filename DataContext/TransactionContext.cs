using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TransactionTestWithNetFramework.Models;

namespace TransactionTestWithNetFramework.DataContext
{
    public class TransactionContext : DbContext
    {

        public TransactionContext() : base("TransactionTest")
        {
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Masters> Masters { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}