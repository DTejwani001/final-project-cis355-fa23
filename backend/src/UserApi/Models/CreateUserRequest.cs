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
    [Required]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// The last name of the user.
    /// </summary>
    [Required]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// The username of the user.
    /// </summary>
    [Required]
    public string Username { get; set; } = null!;

    /// <summary>
    /// The email address of the user.
    /// </summary>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    /// <summary>
    /// The password for the user's account.
    /// </summary>
    [Required]
    //[MinLength(8)]
    [RegularExpression("/(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8}/g", ErrorMessage = "Password must meet requirements")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// The role of the user.
    /// </summary>

    [RoleValidation]
    public string Role { get; set; } = "Member";
}

