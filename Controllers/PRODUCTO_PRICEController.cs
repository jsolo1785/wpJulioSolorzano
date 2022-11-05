using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wpJulioSolorzano.Models;

namespace wpJulioSolorzano.Controllers
{
    public class PRODUCTO_PRICEController : Controller
    {
        private TEST_DEVEntities db = new TEST_DEVEntities();

        // GET: PRODUCTO_PRICE
        public ActionResult Index()
        {
            var pRODUCTO_PRICE = db.PRODUCTO_PRICE.Include(p => p.LIST).Include(p => p.PRODUCT);
            return View(pRODUCTO_PRICE.ToList());
        }

        // GET: PRODUCTO_PRICE/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_PRICE pRODUCTO_PRICE = db.PRODUCTO_PRICE.Find(id);
            if (pRODUCTO_PRICE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_PRICE);
        }

        // GET: PRODUCTO_PRICE/Create
        public ActionResult Create()
        {
            ViewBag.LIST_ID = new SelectList(db.LIST, "ID", "NAME");
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT, "ID", "NAME");
            return View();
        }

        // POST: PRODUCTO_PRICE/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PRODUCT_ID,LIST_ID,DATE_INIT,DATE_END,VALUE,STATE")] PRODUCTO_PRICE pRODUCTO_PRICE)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTO_PRICE.Add(pRODUCTO_PRICE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LIST_ID = new SelectList(db.LIST, "ID", "NAME", pRODUCTO_PRICE.LIST_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT, "ID", "NAME", pRODUCTO_PRICE.PRODUCT_ID);
            return View(pRODUCTO_PRICE);
        }

        // GET: PRODUCTO_PRICE/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_PRICE pRODUCTO_PRICE = db.PRODUCTO_PRICE.Find(id);
            if (pRODUCTO_PRICE == null)
            {
                return HttpNotFound();
            }
            ViewBag.LIST_ID = new SelectList(db.LIST, "ID", "NAME", pRODUCTO_PRICE.LIST_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT, "ID", "NAME", pRODUCTO_PRICE.PRODUCT_ID);
            return View(pRODUCTO_PRICE);
        }

        // POST: PRODUCTO_PRICE/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PRODUCT_ID,LIST_ID,DATE_INIT,DATE_END,VALUE,STATE")] PRODUCTO_PRICE pRODUCTO_PRICE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO_PRICE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LIST_ID = new SelectList(db.LIST, "ID", "NAME", pRODUCTO_PRICE.LIST_ID);
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT, "ID", "NAME", pRODUCTO_PRICE.PRODUCT_ID);
            return View(pRODUCTO_PRICE);
        }

        // GET: PRODUCTO_PRICE/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO_PRICE pRODUCTO_PRICE = db.PRODUCTO_PRICE.Find(id);
            if (pRODUCTO_PRICE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO_PRICE);
        }

        // POST: PRODUCTO_PRICE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PRODUCTO_PRICE pRODUCTO_PRICE = db.PRODUCTO_PRICE.Find(id);
            db.PRODUCTO_PRICE.Remove(pRODUCTO_PRICE);
            db.SaveChanges();
            return RedirectToAction("Index");
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
