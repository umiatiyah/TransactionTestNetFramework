using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionTestWithNetFramework.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        public int Unit { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}