using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SourceParkAPI.Models
{
    public class PostModel
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string PasswordHash { get; set; }
        
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }
    }
}