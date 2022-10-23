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
    public class ProductsController : Controller
    {
        private TransactionContext db = new TransactionContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            var prd = await db.Products.ToListAsync();
            List<ProductResponse> products = new List<ProductResponse>();
            foreach (var p in prd)
            {
                products.Add(new ProductResponse
                {
                    ID = p.ID,
                    ProductName = p.ProductName,
                    Unit = p.Unit == 0 ? "Kg" : p.Unit == 1 ? "dus" : p.Unit == 2 ? "kaleng" : "",
                    Price = p.Price,
                    Stock = p.Stock
                });
            }
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductResponse prd = new ProductResponse()
            {
                ID = product.ID,
                ProductName = product.ProductName,
                Unit = product.Unit == 0 ? "Kg" : product.Unit == 1 ? "dus" : product.Unit == 2 ? "kaleng" : "",
                Stock = product.Stock,
                Price = product.Price
            };
            return View(prd);
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            await GetMasterProduct();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ProductName,Unit,Stock,Price")] Products product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            await GetMasterProduct();
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ProductName,Unit,Stock,Price")] Products product)
        {
            Console.WriteLine(product.ID);
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductResponse prd = new ProductResponse()
            {
                ID = product.ID,
                ProductName = product.ProductName,
                Unit = product.Unit == 0 ? "Kg" : product.Unit == 1 ? "dus" : product.Unit == 2 ? "kaleng" : "",
                Stock = product.Stock,
                Price = product.Price
            };
            return View(prd);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Products product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<List<SelectListItem>> GetMasterProduct()
        {
            var masterProducts = await db.Masters.Where(e => e.Code == "uproduct").ToListAsync();
            List<SelectListItem> MList = new List<SelectListItem>();
            MList = masterProducts
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
