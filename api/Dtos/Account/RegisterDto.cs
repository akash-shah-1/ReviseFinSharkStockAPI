using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations; // Add this package if not already included

namespace api.Dtos.Account;

public class RegisterDto
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 12, ErrorMessage = "Password must be at least 12 characters long")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}