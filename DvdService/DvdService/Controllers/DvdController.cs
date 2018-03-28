using DvdData;
using DvdModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdService.Controllers
{
    [EnableCors(origins: "*", methods: "*", headers: "*")]
    public class DvdController : ApiController
    {
        //Get all
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = DvdRepoFactory.Create();

            List<Dvd> dvds = repo.GetAll();

            if (dvds == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVDs found")),
                    ReasonPhrase = "DVD list Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvds);
        }


        //Get by ID
        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            var repo = DvdRepoFactory.Create();

            Dvd dvd = repo.Get(id);

            if (dvd == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVD found with id = {0}", id)),
                    ReasonPhrase = "DVD Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvd);
        }


        //Get by title
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = DvdRepoFactory.Create();

            List<Dvd> dvds = repo.GetAllByTitle(title);

            if (dvds == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVDs found with title \"{0}\"", title)),
                    ReasonPhrase = "DVDs Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvds);
        }


        //Get by year
        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(int releaseYear)
        {
            var repo = DvdRepoFactory.Create();

            List<Dvd> dvds = repo.GetAllByYear(releaseYear);

            if (dvds == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVDs found with release year {0}", releaseYear)),
                    ReasonPhrase = "DVDs Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvds);
        }


        //Get by director
        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {
            var repo = DvdRepoFactory.Create();

            List<Dvd> dvds = repo.GetAllByDirector(directorName);

            if (dvds == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVDs found with director name \"{0}\"", directorName)),
                    ReasonPhrase = "DVDs not found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvds);
        }
        
        //Get by rating
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            var repo = DvdRepoFactory.Create();

            List<Dvd> dvds = repo.GetAllByRating(rating);

            if (dvds == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVDs found with rating = {0}", rating)),
                    ReasonPhrase = "DVDs not found"
                };
                throw new HttpResponseException(resp);
            }
            return Ok(dvds);
        }


        //Create a new DVD
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create(Dvd dvd)
        {
            var repo = DvdRepoFactory.Create();

            //Validate here
            //All items that DVDs can be searched by must be valid (Title,Rating,Director,ReleaseYear)
            //Empty title
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a Title")),
                    ReasonPhrase = "DVD not created"
                };
                throw new HttpResponseException(resp);
            }

            //Empty or invalid release year 
            if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Release year must be only 4 digits (ex. 1997)")),
                    ReasonPhrase = "DVD not created"
                };
                throw new HttpResponseException(resp);
            }

            //Empty director name
            if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a Director name")),
                    ReasonPhrase = "DVD not created"
                };
                throw new HttpResponseException(resp);
            }

            //Empty rating 
            if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a rating even if unrated")),
                    ReasonPhrase = "DVD not created"
                };
                throw new HttpResponseException(resp);
            }

            //If vaild Add to the repo and return a 201 response 
            repo.Create(dvd);
            return Created($"/dvd/{dvd.DvdId}", dvd);
        }



        //Update/Edit DVD
        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            var repo = DvdRepoFactory.Create();

            //Validate here
            //All items that DVDs can be searched by must be valid (Title,Rating,Director,ReleaseYear)
            
            //Changed ID is invalid
            if (dvd.DvdId != id)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Cannot change DVD ID")),
                    ReasonPhrase = "DVD not updated"
                };
                throw new HttpResponseException(resp);
            }

            //Empty title
            if (dvd.Title == " " || string.IsNullOrEmpty(dvd.Title))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a Title")),
                    ReasonPhrase = "DVD not updated"
                };
                throw new HttpResponseException(resp);
            }

            //Empty or invalid release year 
            if (dvd.ReleaseYear < 1000 || dvd.ReleaseYear > 9999)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Release year must be only 4 digits (ex. 1997)")),
                    ReasonPhrase = "DVD not updated"
                };
                throw new HttpResponseException(resp);
            }

            //Empty director name
            if (dvd.Director == " " || string.IsNullOrEmpty(dvd.Director))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a Director name")),
                    ReasonPhrase = "DVD not updated"
                };
                throw new HttpResponseException(resp);
            }

            //Empty rating 
            if (dvd.Rating == " " || string.IsNullOrEmpty(dvd.Rating))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Must enter a rating even if unrated")),
                    ReasonPhrase = "DVD not updated"
                };
                throw new HttpResponseException(resp);
            }

            //If vaild Add to the repo and return a 201 response 
            repo.Update(dvd);
        }


        //Delete Dvd
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            var repo = DvdRepoFactory.Create();

            Dvd dvd = repo.Get(id);

            if (dvd == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No DVD found with id = {0}", id)),
                    ReasonPhrase = "DVD Not found and deleted"
                };
                throw new HttpResponseException(resp);
            }
            repo.Delete(id);
        }

        //Action to get Chorme to chill out
        [Route("dvd/{id}")]
        [AcceptVerbs("OPTIONS")]
        public IHttpActionResult Options(int id)
        {
            return Ok();
        }

        //Action to get Chorme to chill out
        [Route("dvd")]
        [AcceptVerbs("OPTIONS")]
        public IHttpActionResult Options()
        {
            return Ok();
        }

    }
}
