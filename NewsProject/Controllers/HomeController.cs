using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsProject.Models;

namespace NewsProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? pageNumber,int? pagesize)
        {
            
            pageNumber = pageNumber ?? 1;
            pagesize = pagesize ?? 5;
            ViewBag.pageNum = pageNumber;
            try
            {
                using (var dbContext = new NewsContext())
                {
                    ViewBag.Count = (int)Math.Ceiling((double)dbContext.New.Count() / (int)pagesize);
                    var item = dbContext.New.OrderByDescending(o => o.ID).Skip(((int)pageNumber - 1) * (int)pagesize).Take((int)pagesize)
                        .ToList();
                        
                        
                    return View(item);
                }
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult AddNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNews(News obj)
        {
            try
            {
                using (var dbContext = new NewsContext())
                {
                    dbContext.New.Add(obj);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception)
            {
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult DeleteNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteNews(int id)
        {
            try
            {
                using (var dbContext = new NewsContext())
                {
                    var item = dbContext.New.Find(id);
                    dbContext.New.Remove(item);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                return View();
            }

        }
    }
}