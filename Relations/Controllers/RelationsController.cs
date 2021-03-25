using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Relations.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Relations.Controllers
{
    public class RelationsController : Controller
    {
        private readonly RelationsContext _db;

        public RelationsController(RelationsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Relation> model = _db.Relations.Include(item => item.Category).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Relation item)
        {
            _db.Relations.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Relation thisItem = _db.Relations.FirstOrDefault(item => item.ItemId == id);
            return View(thisItem);
        }

        public ActionResult Delete(int id)
        {
            Relation thisItem = _db.Relations.FirstOrDefault(item => item.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Relation thisItem = _db.Relations.FirstOrDefault(item => item.ItemId == id);
            _db.Relations.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Relation thisItem = _db.Relations.FirstOrDefault(item => item.ItemId == id);
            ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
            return View(thisItem);
        }
    }
}