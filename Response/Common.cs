using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionTestWithNetFramework.Models;

namespace TransactionTestWithNetFramework.Response
{
    public class Common
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class Auth : Common
    {
        public string Username { get; set; }
    }
}