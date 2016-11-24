using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Facebook4532.Models;

namespace Facebook4532.Controllers
{
    public class PublicacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Publicacions
        public JsonResult ListaPublicaciones()
        {
            var orden = db.Publicaciones.ToList().OrderByDescending(e => e.Id);
            return Json(orden, JsonRequestBehavior.AllowGet);
        }

        // GET: Publicacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicaciones.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // GET: Publicacions/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Publicacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,MeGusta,UsuarioId")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Publicaciones.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioId = new SelectList(db.Usuarios, "IdUsuario", "Nombre", publicacion.UsuarioId);
            return View(publicacion);
        }

        // GET: Publicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicaciones.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "IdUsuario", "Nombre", publicacion.UsuarioId);
            return View(publicacion);
        }

        // POST: Publicacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,MeGusta,UsuarioId")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "IdUsuario", "Nombre", publicacion.UsuarioId);
            return View(publicacion);
        }

        // GET: Publicacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicaciones.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // POST: Publicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacion publicacion = db.Publicaciones.Find(id);
            db.Publicaciones.Remove(publicacion);
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

        

        [HttpPost]
        public JsonResult crearPublicacion(Usuario usuario, Publicacion publicacion)
        {
            Usuario user = db.Usuarios.Where(u => u.Email == usuario.Email).FirstOrDefault();
            var publicar = publicacion;
            publicacion.Usuario = user;
            publicacion.UsuarioId = user.IdUsuario;
            publicacion.MeGusta = 0;

            if (ModelState.IsValid)
            {
                db.Publicaciones.Add(publicacion);
                db.SaveChanges();
            }
            return Json(publicacion, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModificarMg(Publicacion publicacion)
        {
            Publicacion p = db.Publicaciones.Find(publicacion.Id);
            p.MeGusta = p.MeGusta + 1;
            db.SaveChanges();
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}
