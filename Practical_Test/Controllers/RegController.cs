using Practical_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_Test.Controllers
{
    public class RegController : Controller
    {
        private RegEntities1 dbmodel = new RegEntities1();

        // GET: Reg/Index
        public ActionResult Index()
        {
            
                return View(dbmodel.Registrations.ToList());
            

            //ViewBag.reg = dbmodel.Registrations.ToList();
            //return bas

        }


        // GET: Reg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reg/Create
        [HttpPost]
        public ActionResult Create(Registration reg)
        {
            try
            {
                    dbmodel.Registrations.Add(reg);
                    dbmodel.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reg/Edit/5
        public ActionResult Edit(int id)
        {

            var reg = dbmodel.Registrations.Find(id);
            return View("Edit", reg);
               
        }

        // POST: Reg/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Registration reg)
        {
            try
            {
                dbmodel.Entry(reg).State = System.Data.Entity.EntityState.Modified;
                dbmodel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reg/Delete/5
        public ActionResult Delete(int id)
        {

            var reg = dbmodel.Registrations.Find(id);
            dbmodel.Registrations.Remove(reg);
            dbmodel.SaveChanges();
            return RedirectToAction("Index"); 
        }
       
    }
}
