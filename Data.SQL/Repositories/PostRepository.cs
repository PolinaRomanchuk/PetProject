using Data.SQL.Interfaces;
using Data.SQL.Models;

namespace Data.SQL.Repositories
{
    public class PostRepository: BaseRepository<Post>, IPostRepository
    {
        public PostRepository(WebContext webContext) : base(webContext) { }

    }
}
