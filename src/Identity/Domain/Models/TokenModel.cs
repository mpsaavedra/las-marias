namespace LasMarias.Identity.Domain.Models;

/// <summary>
/// Authentication token
/// </summary>
public class TokenModel
{
    /// <summary>
    /// Authentication token created when session starts
    /// </summary>
    public string Token { get; set; }
}