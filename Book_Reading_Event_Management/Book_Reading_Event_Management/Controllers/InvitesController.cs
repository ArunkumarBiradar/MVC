using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Book_Reading_Event_Management.Models;

namespace Book_Reading_Event_Management.Controllers
{
    [Authorize]
    public class InvitesController : Controller
    {
        private BookReadingEventManagementEntities db = new BookReadingEventManagementEntities();

        // GET: Invites

        [Authorize(Users = "arunkumar.biradar@nagarro.com")]
        public ActionResult Index()
        {
            return View(db.Invites.ToList());
        }
        public ActionResult InvitedEvents()
        {
            var Email = (string)Session["Email"];
            var InvitedEvents = db.Invites.Where(x => x.Email.Contains(Email)).ToList();
            return View(InvitedEvents);

            //var InvitedEvents2 = db.Events.Where(db.Invites.Where(x=>x.Email.Contains(Email))).ToList();
            //return View(InvitedEvents2);

            //var InvitedEvents1 = db.Invites.Join(db.Events,
            //   inv => inv.EventID,
            //   eve => eve.EventID,
            //   (inv, eve) => new { inv, eve }).
            //   Select(x => new
            //   {
            //       Title = x.eve.Title,
            //       EventID = x.eve.EventID,
            //       Email = x.inv.Email,
            //   }
            //   ).Where(x => x.Email.Contains(Email)).ToList();
            //return ( InvitedEvents1);
        }
        // GET: Invites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // GET: Invites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Email")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                db.Invites.Add(invite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invite);
        }

        // GET: Invites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // POST: Invites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,Email")] Invite invite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invite);
        }

        // GET: Invites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invite invite = db.Invites.Find(id);
            if (invite == null)
            {
                return HttpNotFound();
            }
            return View(invite);
        }

        // POST: Invites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invite invite = db.Invites.Find(id);
            db.Invites.Remove(invite);
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
