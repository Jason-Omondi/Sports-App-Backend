using SportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SportsAPI.Controllers
{
    public class ArticlesController : ApiController
    {
        private SportsDbContext db = new SportsDbContext();

        // POST: api/articles
        [HttpPost]
        public IHttpActionResult CreateArticle([FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Article cannot be null");
            }

            if (db.Articles.Any(a => a.Title == article.Title))
            {
                return Conflict(); // HTTP 409 Conflict
            }

            db.Articles.Add(article);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // PUT: api/articles/{id}
        [HttpPut]
        public IHttpActionResult UpdateArticle(int id, [FromBody] Article article)
        {
            if (article == null)
            {
                return BadRequest("Article cannot be null");
            }

            var existingArticle = db.Articles.Find(id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Title = article.Title;
            existingArticle.Content = article.Content;
            existingArticle.PublishedDate = article.PublishedDate;

            db.SaveChanges();

            return Ok(existingArticle);
        }

        // DELETE: api/articles/{id}
        [HttpDelete]
        public IHttpActionResult DeleteArticle(int id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Articles.Remove(article);
            db.SaveChanges();

            return Ok();
        }
    }
}