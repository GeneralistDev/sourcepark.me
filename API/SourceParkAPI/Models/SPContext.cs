using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SourceParkAPI.Models
{
    public class SpContext: DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<PostModel> Posts { get; set; }
    }
}