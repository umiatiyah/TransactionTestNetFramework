using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TransactionTestWithNetFramework.DataContext;
using TransactionTestWithNetFramework.Models;
using TransactionTestWithNetFramework.Response;
using System.Data.Entity;

namespace TransactionTestWithNetFramework.Controllers
{
    /// <summary>
    /// this controller use API Controller (can called in postman)
    /// </summary>
    public class OrdersController : ApiController
    {
        private TransactionContext db = new TransactionContext();
        // GET: Orders
        [System.Web.Http.HttpGet]
        public async Task<OrderListDto> GetOrders()
        {
            OrderListDto res = new OrderListDto();
            try
            {
                var orderList = from u in db.Orders
                            join p in db.Customers on u.CustomerID equals p.ID into gj
                            from x in gj.DefaultIfEmpty()
                            select new
                            {
                                id = u.ID,
                                customer_id = u.CustomerID,
                                customer_name = x.CustomerName,
                                customer_type = x.CustomerType,
                                order_number = u.OrderNumber,
                                order_date = u.OrderDate,
                                ship_date = u.ShipDate,
                                ship_name = u.ShipName,
                                ship_phone = u.ShipPhone,
                                term_of_payment = u.TermOfPayment,
                                nominal_amount = u.NominalAmount,
                                note = u.Note
                            };

                //var orderList = await db.Orders.ToListAsync();
                List<OrderResponse> order = new List<OrderResponse>();
                foreach (var i in orderList)
                {
                    order.Add(new OrderResponse
                    {
                        ID = i.id,
                        CustomerID = i.customer_id,
                        CustomerName = i.customer_name,
                        CustomerType = await db.Masters.Where(e => e.Value == i.customer_type && e.Code == "custype").Select(e => e.Description).FirstOrDefaultAsync(),
                        OrderNumber = i.order_number,
                        OrderDate = i.order_date,
                        ShipDate = i.ship_date,
                        ShipName = i.ship_name,
                        ShipPhone = i.ship_phone,
                        NominalAmount = i.nominal_amount,
                        TermOfPayment = i.term_of_payment,
                        Note = i.note
                    });
                }
                res = new OrderListDto
                {
                    Data = order,
                    Status = true,
                    Message = "order retrieved successfully!"
                };
            }
            catch (Exception e)
            {
                res = new OrderListDto
                {
                    Data = null,
                    Status = false,
                    Message = "failed get data: "+ e
                };
            }
            return res;
        }

        // POST: Orders/Create
        [System.Web.Http.HttpPost]
        public async Task<Common> CreateOrder([FromBody] Order order)
        {
            var res = new Common();
            try
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                res = new Common()
                {
                    Status = true,
                    Message = "Order Saved!"
                };
            } 
            catch (Exception e)
            {
                res = new Common()
                {
                    Status = false,
                    Message = "Error Exception: " + e
                };
            }
            return res;
        }
    }
}