namespace Orun.Domain;

using System.Collections.Generic;

/// <summary>
/// represents an error handler, class
/// </summary>
public abstract class Payload
{
    /// <summary>
    /// returns a new instanc of the Payload
    /// </summary>
    protected Payload(IReadOnlyList<UserError>? errors = null)
    {
        Errors = errors;
    }

    /// <summary>
    /// returns the errores list occurred
    /// </summary>
    public IReadOnlyList<UserError>? Errors { get; }
}