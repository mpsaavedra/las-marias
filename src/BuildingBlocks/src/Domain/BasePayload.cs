namespace Orun.Domain;

using HotChocolate;
using System.Collections.Generic;

/// <summary>
/// Base payload used to return values from request
/// </summary>
public class BasePayload<TEntity> : Payload where TEntity : class
{
    /// <summary>
    /// returns a new instance of the <see cref="BasePayload{TEntity}" /> class
    /// </summary>
    protected BasePayload(TEntity entity)
    {
    }

    /// <summary>
    /// returns a new instance of the <see cref="BasePayload{TEntity}" /> class
    /// </summary>
    protected BasePayload(IReadOnlyList<UserError> errors) : base(errors)
    {

    }

    /// <summary>
    /// value handle by Paylads
    /// </summary>
    public TEntity? Payload { get; }
}