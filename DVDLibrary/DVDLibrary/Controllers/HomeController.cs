using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDLibrary.Controllers
{
    public class HomeController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(DVDRepo.GetAll());
        }

        [Route("dvd/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByYear(string releaseYear)
        {
            List<DVD> found = DVDRepo.GetAllByYear(releaseYear);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvd/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByTitle(string title)
        {
            List<DVD> found = DVDRepo.GetAllByTitle(title);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvd/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByRating(string rating)
        {
            List<DVD> found = DVDRepo.GetAllByRating(rating);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        [Route("dvd/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllByDirector(string director)
        {
            return Ok(DVDRepo.GetAllByDirector(director));
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            return Ok(DVDRepo.Get(id));
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            DVDRepo.Create(dvd);
            return Created($"/dvd{dvd.MovieId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Edit(int id, DVD dvd)
        {
            DVDRepo.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            DVDRepo.Delete(id);
        }
    }
}
