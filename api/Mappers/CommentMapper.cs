using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Content,
                Content = commentModel.Content,
                CreatedAt = commentModel.CreatedAt,
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCreateComment(this CreateCommentDto commentDto, int StockId)
        {
            return new Comment
            {
                Title = commentDto.Content,
                Content = commentDto.Content,
                StockId = StockId
            };
        }

        public static Comment ToUpdateComment(this UpdateCommentDto updateDto)
        {
            return new Comment
            {
                Title = updateDto.Content,
                Content = updateDto.Content,
            };
        }

    }
}
