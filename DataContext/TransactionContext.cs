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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}