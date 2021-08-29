using Internet.Models;
using Internet.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Internet.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepo<Movies> moviesrepo;
        private readonly IMoviesRepo<Actors> actorsrepo;
        
        private readonly IWebHostEnvironment webHostEnvironment;
        

        public MoviesController(IMoviesRepo<Movies> moviesrepo,IMoviesRepo<Actors> actorsrepo, 
            IWebHostEnvironment webHostEnvironment)
        {
            this.moviesrepo = moviesrepo;
            this.actorsrepo = actorsrepo;
            
            this.webHostEnvironment = webHostEnvironment;
         
        }
        // GET: MoviesController
        public ActionResult Index()
        {
            var movies = moviesrepo.List();
            return View(movies);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movie = moviesrepo.Find(id);
            return View(movie);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            var model = new MoviesViewModel
            {
                Actor = actorsrepo.List().ToList()
            };
            return View(model);
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoviesViewModel model)
        {
            try
            {
                string filename = string.Empty;

                if (model.ImgFile != null)
                {
                    string uploadfile = Path.Combine(webHostEnvironment.WebRootPath, "upload");
                    filename = model.ImgFile.FileName;
                    string fullpath = Path.Combine(uploadfile, filename);
                    //string des = model.ImgFile.FilePath
                    
                    try
                    {

                        model.ImgFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                        
                    } catch(Exception ex)
                    {
                        var m = ex.Message;
                    }
                    


                }

                var movie = new Movies
                {
                    movie_name = model.movie_name,
                    Desc = model.Desc,
                    ImgUrl = filename,
                    rate = model.rate,
                    Actor = actorsrepo.Find(model.actor_id)
                };
                moviesrepo.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            var mov = moviesrepo.Find(id);
            //var movactor_id = mov.Actor == null ? mov.Actor.actor_id : mov.Actor.actor_id;
            
            if(mov.Actor == null)
            {
                var nullmodel = new MoviesViewModel

                {

                    movie_id = mov.movie_id,
                    movie_name = mov.movie_name,
                    Desc = mov.Desc,
                    ImgUrl = mov.ImgUrl,
                    rate = mov.rate,
                     //actor_id = 1,
                    Actor = actorsrepo.List().ToList()


                };
                return View(nullmodel);
            }

            var movieview = new MoviesViewModel

            {
                  
                movie_id = mov.movie_id,
                movie_name = mov.movie_name,
                Desc = mov.Desc,
                ImgUrl = mov.ImgUrl,
                rate = mov.rate,
                actor_id = mov.Actor.actor_id,
                Actor = actorsrepo.List().ToList()

            };

            return View(movieview);
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoviesViewModel model)
        {
            try
            {
                var actors = actorsrepo.Find(model.actor_id);
                var movie = new Movies
                {
                    movie_id = model.movie_id,
                    movie_name = model.movie_name,
                    rate = model.rate,
                    Desc =  model.Desc,
                    ImgUrl = model.ImgUrl,
                    Actor = actors
                };
                moviesrepo.Update(movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = moviesrepo.Find(id);
            return View(movie);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Movies model)
        {
            try
            {
                moviesrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public ActionResult Searching(string term)
        {
            var result = moviesrepo.Search(term);
            return View("Index", result);
        }

    }
}
