using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ApplicationDBContext dbContext, ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _dbContext = dbContext;
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var Comments = await _commentRepo.GetAllAsync();
            var commentDto = Comments.Select(c => c.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentDto, [FromRoute] int stockId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _stockRepo.StockExist(stockId))
            {
                return BadRequest("Stock not exist");
            }
            var comment = commentDto.ToCreateComment(stockId);
            await _commentRepo.CreateAsync(comment);
            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToUpdateComment());
            if (comment == null) return BadRequest("Comment not found");
            return Ok(new
            {
                message = "Stock Updated Successfully",
                UpdatedStock = comment.ToCommentDto()
            });

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment = await _commentRepo.DeleteByIdAsync(id);
            if (comment == null) return BadRequest("Comment Not Found");
            return Ok(new
            {
                message = "Comment Deleted Successfully"
            });
        }
    }
}
