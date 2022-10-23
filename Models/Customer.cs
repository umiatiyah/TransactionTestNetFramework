using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionTestWithNetFramework.Models
{
    public class Customers
    {
        public int ID { get; set; }
        public string NIK { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("customer_type")]
        public int CustomerType { get; set; }
        [Column("no_telp")]
        public string NoTelp { get; set; }
        public string Address { get; set; }
        [Column("no_rekening")]
        public string NoRekening { get; set; }
    }
}