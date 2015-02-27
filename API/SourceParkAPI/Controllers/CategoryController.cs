using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SourceParkAPI.Models;

namespace SourceParkAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private SpContext db = new SpContext();

        // GET: api/Category
        public IQueryable<CategoryModel> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Category/5
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult GetCategoryModel(int id)
        {
            CategoryModel categoryModel = db.Categories.Find(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        // PUT: api/Category/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoryModel(int id, CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryModel.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(categoryModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Category
        [Authorize(Roles="Admin")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult PostCategoryModel(CategoryModel categoryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categoryModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoryModel.CategoryId }, categoryModel);
        }

        // DELETE: api/Category/5
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult DeleteCategoryModel(int id)
        {
            CategoryModel categoryModel = db.Categories.Find(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categoryModel);
            db.SaveChanges();

            return Ok(categoryModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryModelExists(int id)
        {
            return db.Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}