using Data.SQL.Models;

namespace PetProject.Models
{
    public class PostViewModel
    {
        public string ImageUrl { get; set; }
        public IFormFile? ImgUrlFile { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public string? Description { get; set; }
        public int? CountOfLikes { get; set; }
    }
}
