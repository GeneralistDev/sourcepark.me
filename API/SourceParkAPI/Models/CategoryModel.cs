using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceParkAPI.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(50)]
        [Index("Name", IsUnique = true)]
        public string Name { get; set; }

        public virtual List<PostModel> Posts { get; set; }
    }
}