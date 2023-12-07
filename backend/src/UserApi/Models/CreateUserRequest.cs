using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

/// <summary>
/// Represents a request to create a new user.
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    /// The first name of the user.
    /// </summary>
    [Required ]
    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The last name of the user.
    /// </summary>
    [Required]
     [StringLength(255)]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The username of the user.
    /// </summary>
    [Required]
     [StringLength(255)]
    public string Username { get; set; } = null!;

    /// <summary>
    /// The email address of the user.
    /// </summary>
    //[Required]
    //[EmailAddress]

     [Required(ErrorMessage = "Email address is required.")]
     [EmailAddress(ErrorMessage = "Invalid email address.")]
      [StringLength(255)]
    public string Email { get; set; } = null!;

    /// <summary>
    /// The password for the user's account.
    /// </summary>
    [Required]
    //[MinLength(8)]
    [RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g", ErrorMessage = "Password must be at least 8 characters long and include at least one lowercase letter, one uppercase letter, and one digit.")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// The role of the user.
    /// </summary>

    [RoleValidation]
    public string Role { get; set; } = "Member";
}

