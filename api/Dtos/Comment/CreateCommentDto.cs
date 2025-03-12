using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title must be 5 character")]
        [MaxLength(50, ErrorMessage ="Title cannot be over 50")] 
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "Content must be 5 character")]
        [MaxLength(300, ErrorMessage = "Content cannot be over 50")]
        public string Content { get; set; } = string.Empty;
    }
}
