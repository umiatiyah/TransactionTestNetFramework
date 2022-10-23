using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransactionTestWithNetFramework.DataContext;
using TransactionTestWithNetFramework.Models;
using TransactionTestWithNetFramework.Response;

namespace TransactionTestWithNetFramework.Controllers
{
    /// <summary>
    /// this controller use MVC generated
    /// </summary>
    public class CustomersController : Controller
    {
        private TransactionContext db = new TransactionContext();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            var cust = await db.Customers.ToListAsync();
            List<CustomerResponse> customers = new List<CustomerResponse>();
            foreach (var c in cust)
            {                
                customers.Add(new CustomerResponse
                {
                    ID = c.ID,
                    NIK = c.NIK,
                    CustomerName = c.CustomerName,
                    CustomerType = c.CustomerType == 0 ? "Perorangan" : c.CustomerType == 1 ? "Perusahaan" : "",
                    NoTelp = c.NoTelp,
                    Address = c.Address,
                    NoRekening = c.NoRekening
                });
            }
            return View(customers);

            //return View(await db.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            CustomerResponse cust = new CustomerResponse()
            {
                ID = customer.ID,
                NIK = customer.NIK,
                CustomerName = customer.CustomerName,
                CustomerType = customer.CustomerType == 0 ? "Perorangan" : customer.CustomerType == 1 ? "Perusahaan" : "",
                NoTelp = customer.NoTelp,
                Address = customer.Address,
                NoRekening = customer.NoRekening
            };
            return View(cust);
        }

        // GET: Customers/Create
        public async Task<ActionResult> Create()
        {
            await GetMasterCustomerType();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,NIK,CustomerName,CustomerType,NoTelp,Address,NoRekening")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            await GetMasterCustomerType();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,NIK,CustomerName,CustomerType,NoTelp,Address,NoRekening")] Customers customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            CustomerResponse cust = new CustomerResponse()
            {
                ID = customer.ID,
                NIK = customer.NIK,
                CustomerName = customer.CustomerName,
                CustomerType = customer.CustomerType == 0 ? "Perorangan" : customer.CustomerType == 1 ? "Perusahaan" : "",
                NoTelp = customer.NoTelp,
                Address = customer.Address,
                NoRekening = customer.NoRekening
            };
            return View(cust);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customers customer = await db.Customers.FindAsync(id);
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<List<SelectListItem>> GetMasterCustomerType()
        {
            var masterCusType = await db.Masters.Where(e => e.Code == "custype").ToListAsync();
            List<SelectListItem> MList = new List<SelectListItem>();
            MList = masterCusType
                     .Select(i => new SelectListItem()
                     {
                         Text = i.Description,
                         Value = i.Value.ToString()
                     }).ToList();
            List<SelectListItem> listMaster = new List<SelectListItem>();
            foreach (var m in MList)
            {
                listMaster.Add(new SelectListItem
                {
                    Value = m.Value,
                    Text = m.Text
                });
            }
            return ViewBag.Master = listMaster;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
