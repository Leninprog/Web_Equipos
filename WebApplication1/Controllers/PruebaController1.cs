﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Liga_Pro.Controllers
{
    public class PruebaController1 : Controller
    {
        // GET: PruebaController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: PruebaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PruebaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PruebaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PruebaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PruebaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PruebaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PruebaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
