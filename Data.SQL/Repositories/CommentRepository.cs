using Data.SQL.Interfaces;
using Data.SQL.Models;

namespace Data.SQL.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(WebContext webContext) : base(webContext) { }
    }
}
