using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransactionTestWithNetFramework.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Column("customer_id")]
        public int CustomerID { get; set; }
        [Column("order_number")]
        public string OrderNumber { get; set; }
        [Column("order_date")]
        public DateTime OrderDate { get; set; }
        [Column("ship_date")]
        public DateTime ShipDate { get; set; }
        [Column("ship_name")]
        public string ShipName { get; set; }
        [Column("ship_phone")]
        public string ShipPhone { get; set; }
        [Column("term_of_payment")]
        public int TermOfPayment { get; set; }
        [Column("nominal_amount")]
        public decimal NominalAmount { get; set; }
        [Column("note")]
        public string Note { get; set; }
    }
}