using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TransactionTestWithNetFramework.Models
{
    public class Masters
    {
        public int ID { get; set; }
        [Column("master_name")]
        public string MasterName { get; set; }
        public string Code { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}