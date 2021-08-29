using Internet.Models;
using Internet.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IMoviesRepo<Actors> actorsrepo;

        public ActorsController(IMoviesRepo<Actors> actorsrepo)
        {
            this.actorsrepo = actorsrepo;
        }
        // GET: ActorsController
        public ActionResult Index()
        {
            var actors = actorsrepo.List();
            return View(actors);
        }

        // GET: ActorsController/Details/5
        public ActionResult Details(int id)
        {
            var actors = actorsrepo.Find(id);
            return View(actors);
        }

        // GET: ActorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actors model)
        {
            try
            {
                actorsrepo.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ActorsController/Edit/5
        public ActionResult Edit(int id)
        {
            var actor = actorsrepo.Find(id);
            return View(actor);
        }

        // POST: ActorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actors model)
        {
            try
            {
                actorsrepo.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: ActorsController/Delete/5
        public ActionResult Delete(int id)
        {
            var actor = actorsrepo.Find(id);
            return View(actor);
        }

        // POST: ActorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Actors model)
        {
            try
            {
                actorsrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}
