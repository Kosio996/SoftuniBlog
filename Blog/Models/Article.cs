﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Article
    {
        private ICollection<Tag> tags;

        public Article()
        {
            this.tags = new HashSet<Tag>();
        }

        public Article(string authorId, string title, string content, int categoryId, int? commentId)
        {
            this.AuthorId = authorId;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.CommentId = commentId;
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public bool IsAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Comment")]
        public int? CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
