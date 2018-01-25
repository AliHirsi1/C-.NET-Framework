using DvdLibrarys.Bll;
using DvdLibrarys.Data.Mock;
using DvdLibrarys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrarys.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        IDvdRepository repos = DvdFactory.Create();

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(repos.GetAll());
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByTitle(string title)
        {
           var dvd = repos.GetByTitle(title);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/releaseYear/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByReleaseYear(int year)
        {
           var dvd = repos.GetByYear(year);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }


        [Route("dvds/directorName/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByDirectorName(string directorName)
        {
            var dvd = repos.GetByDirectorName(directorName);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchByRating(string rating)
        {
            var dvd = repos.GetByRating(rating);
            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int dvdId)
        {
            Dvd dvd = repos.GetOne(dvdId);
           

            if (dvd == null)
            {
                return NotFound();
            }

            return Ok(dvd);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd)
        {
            repos.Add(dvd);
            return Created($"dvds/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(int id, Dvd dvd)
        {
            repos.Edit(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            repos.Delete(id);
        }

        


    }
}
