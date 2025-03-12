using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context; 
        }
        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment> DeleteByIdAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var commentdto = await _context.Comments.FindAsync(id);
            if (commentdto == null) return null;
            return commentdto;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var existComment = await _context.Comments.FindAsync(id);
            if (existComment == null) return null;
            existComment.Title = comment.Title;
            existComment.Content = comment.Content;
            await _context.SaveChangesAsync();
            return existComment;
        }
    }
}
