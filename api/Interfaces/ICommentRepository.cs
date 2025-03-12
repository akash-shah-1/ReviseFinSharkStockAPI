using api.Dtos.Comment;
using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> DeleteByIdAsync(int id);
        Task<Comment?> UpdateAsync(int id, Comment comment);
    }
}
