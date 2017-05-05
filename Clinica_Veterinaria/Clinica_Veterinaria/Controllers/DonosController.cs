using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica_Veterinaria.Models;

namespace Clinica_Veterinaria.Controllers
{
    public class DonosController : Controller
    {
        private VetsDB db = new VetsDB();

        // GET: Donos
        public ActionResult Index()
        {
            return View(db.Donos.ToList().OrderBy(d=>d.Nome));
        }

        // GET: Donos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donos dono = db.Donos.Find(id);
            if (dono == null)
            {
                return HttpNotFound();
            }
            return View(dono);
        }

        // GET: Donos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            //determinar o ID do novo Dono
            int novoID = 0;
            try
            {
                novoID = db.Donos.Max(d => d.DonoID) + 1;
            }
            catch (Exception)
            {
                novoID = 1;
            }
            //outra forma
            //novoID = db.Donos.Last().DonoID + 1;

            //atribuir o novo ID ao respectivo dono
            donos.DonoID = novoID;
            try
            {
                if (ModelState.IsValid) //verificar e os dados são consistentes com a BD
                {
                    db.Donos.Add(donos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocorreu um erro na operação de guardar um novo dono");
                throw;
                /*adicionar a uma classe ERRO
                 * -id
                 * -timestamp
                 * -operação que gerou o erro
                 * -mensagem e erro
                 * -qual o User que gerou o erro
                 * -enviar um email ao utilizador 'Admin' a avisar da ocorrencia do erro
                 * -E.T.C.
                 */
            }

            return View(donos);
        }

        // GET: Donos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donos donos = db.Donos.Find(id);
            if (donos == null)
            {
                return HttpNotFound();
            }
            return View(donos);
        }

        // POST: Donos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // GET: Donos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Donos dono = db.Donos.Find(id);
            if (dono == null)
            {
                return RedirectToAction("Index");
            }
            return View(dono);
        }

        // POST: Donos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //procura o Dono de id "id" na base de dados
            Donos dono = db.Donos.Find(id);
            try
            {
                //remove o resisto encontrado em cima
                db.Donos.Remove(dono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //cria uma mensagem de erro a ser apresentada ao utilizador
                ModelState.AddModelError("",string.Format("ocorreu um erro na eliminação do Dono com ID={0} - {1}",id,dono.Nome));
                return View(dono);
            }
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