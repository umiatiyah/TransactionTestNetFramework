using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TransactionTestWithNetFramework.Models;

namespace TransactionTestWithNetFramework.Response
{
    public class OrderListDto : Common
    {
        public IEnumerable<OrderResponse> Data { get; set; }
    }

    [NotMapped]
    public class OrderResponse : Order
    {
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
    }
}