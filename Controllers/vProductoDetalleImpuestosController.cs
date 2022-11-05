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
    public class vProductoDetalleImpuestosController : Controller
    {
        private TEST_DEVEntities db = new TEST_DEVEntities();

        // GET: vProductoDetalleImpuestos
        public ActionResult Index()
        {
            return View(db.vProductoDetalleImpuestos.ToList());
        }

        // GET: vProductoDetalleImpuestos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vProductoDetalleImpuestos vProductoDetalleImpuestos = db.vProductoDetalleImpuestos.Find(id);
            if (vProductoDetalleImpuestos == null)
            {
                return HttpNotFound();
            }
            return View(vProductoDetalleImpuestos);
        }

        // GET: vProductoDetalleImpuestos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vProductoDetalleImpuestos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCT_ID,PRODUCT_NAME,PRICE_LIST_NAME,PRODUCT_PRICE,PRODUCT_TAX,PERCENTAGE,MONEY,TOTAL")] vProductoDetalleImpuestos vProductoDetalleImpuestos)
        {
            if (ModelState.IsValid)
            {
                db.vProductoDetalleImpuestos.Add(vProductoDetalleImpuestos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vProductoDetalleImpuestos);
        }

        // GET: vProductoDetalleImpuestos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vProductoDetalleImpuestos vProductoDetalleImpuestos = db.vProductoDetalleImpuestos.Find(id);
            if (vProductoDetalleImpuestos == null)
            {
                return HttpNotFound();
            }
            return View(vProductoDetalleImpuestos);
        }

        // POST: vProductoDetalleImpuestos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCT_ID,PRODUCT_NAME,PRICE_LIST_NAME,PRODUCT_PRICE,PRODUCT_TAX,PERCENTAGE,MONEY,TOTAL")] vProductoDetalleImpuestos vProductoDetalleImpuestos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vProductoDetalleImpuestos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vProductoDetalleImpuestos);
        }

        // GET: vProductoDetalleImpuestos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vProductoDetalleImpuestos vProductoDetalleImpuestos = db.vProductoDetalleImpuestos.Find(id);
            if (vProductoDetalleImpuestos == null)
            {
                return HttpNotFound();
            }
            return View(vProductoDetalleImpuestos);
        }

        // POST: vProductoDetalleImpuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            vProductoDetalleImpuestos vProductoDetalleImpuestos = db.vProductoDetalleImpuestos.Find(id);
            db.vProductoDetalleImpuestos.Remove(vProductoDetalleImpuestos);
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
