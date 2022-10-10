using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransactionTestWithNetFramework.DataContext;
using TransactionTestWithNetFramework.Models;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TransactionTestWithNetFramework.Controllers
{
    /// <summary>
    /// this controller use API Controller (can called in postman)
    /// </summary>
    public class MasterDataController : ApiController
    {
        private TransactionContext db = new TransactionContext();
        // GET: api/MasterData
        [HttpGet]
        public async Task<List<Master>> Master()
        {
            var masterProducts = await db.Masters.ToListAsync();
            return masterProducts;
        }
    }
}