using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using System.Data.Entity;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        storeEntities str = new storeEntities();

        public ActionResult Index()
        {

       

            ViewBag.types = str.Types.ToList();
            ViewBag.categories = str.Categories.ToList();

          



            return View();
        }

        public ActionResult Delete(int id)
        {
            Products stu = str.Products.Find(id);
            if (stu == null)
            {
                return RedirectToAction("index");
            }


            str.Products.Remove(stu);
            str.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult add(Products prd)
        {



            ViewBag.types = str.Types.ToList();
            ViewBag.categories = str.Categories.ToList();

            //if (ViewBag.categories.Id == ViewBag.types.Id)
            //{

            //}


            str.Products.Add(prd);
            str.SaveChanges();

            return RedirectToAction("index");

        }
        public ActionResult Update()
        {
    
            ViewBag.products = str.Products.ToList();
            return View();
        }
       
        public ActionResult yenile(int id)
        {


            Products stu = str.Products.Find(id);
            if (stu == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.products = stu;

            ViewBag.types = str.Types.ToList();
            ViewBag.categories = str.Categories.ToList();

            return View();
        }
       
     [HttpPost]
     public ActionResult yenile(Products ptr)
        {

            str.Entry(ptr).State = EntityState.Modified;
            str.SaveChanges();
            return RedirectToAction("index");

        }
   
    }
}