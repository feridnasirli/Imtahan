using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [StringLength(maximumLength:40)]
        public string Title { get; set; }
        [StringLength(maximumLength: 400)]
        public string Description { get; set; }
        public string RedirectURL { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
