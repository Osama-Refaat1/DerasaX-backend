using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Post :BaseEntity
    {
        public string? PhotoUrl { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; } 
        public int LikesCount { get; set; } = 0;
        public int CommentsCount { get; set; } = 0;
        public int ViewsCount { get; set; } = 0;     
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
    }
}
