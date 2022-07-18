namespace Orun.Domain;

using HotChocolate;
using System.Collections.Generic;

/// <summary>
/// Base payload used to return values from request
/// </summary>
public class BasePayload<TEntity> : Payload where TEntity : class
{
    protected BasePayload(TEntity entity)
    {
    }

    protected BasePayload(IReadOnlyList<UserError> errors) : base(errors)
    {

    }

    public TEntity? Payload { get; }
}