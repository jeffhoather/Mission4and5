using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4and5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4and5.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieContext blahContext { get; set; }

        public HomeController(MovieContext someName)
        {
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieCollection()
        {
            ViewBag.categories = blahContext.categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieCollection(MovieEntry entry)
        {
            if (ModelState.IsValid)
                {
                    blahContext.Add(entry);
                    blahContext.SaveChanges();

                    return View("Confirmation", entry);
                }
            else
                {
                    ViewBag.categories = blahContext.categories.ToList();
                    return View(entry);
                }
        }

        [HttpGet]
        public IActionResult MovieDatabase()
        {
            var applications = blahContext.entries
                .Include(x => x.Category)
                .ToList();
            
            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int MovieID)
        {
            ViewBag.categories = blahContext.categories.ToList();

            var application = blahContext.entries.Single(x => x.MovieID == MovieID);

            return View("MovieCollection", application);
        }
        [HttpPost]
        public IActionResult Edit(MovieEntry x)
        {
            blahContext.Update(x);
            blahContext.SaveChanges();

            return RedirectToAction("MovieDatabase");
        }

        [HttpGet]
        public IActionResult Delete(int MovieID)
        {
            var application = blahContext.entries.Single(x => x.MovieID == MovieID);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry x)
        {
            blahContext.entries.Remove(x);
            blahContext.SaveChanges();
            
            return RedirectToAction("MovieDatabase");
        }
    }
}
