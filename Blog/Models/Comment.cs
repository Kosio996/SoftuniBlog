using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        private ICollection<Article> articles;
       
        public Comment(string comment)
        {
            this.Comments = comment;
            this.articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }
        
        public string Comments { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}