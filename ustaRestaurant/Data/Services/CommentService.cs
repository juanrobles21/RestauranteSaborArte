using ustaRestaurant.Data.Base;
using ustaRestaurant.Models;

namespace ustaRestaurant.Data.Services
{
    public class CommentService : EntityBaseRepository<Comment>, ICommentService
    {
        public CommentService(ApplicationDbContext context) : base(context) { }
    }
}
