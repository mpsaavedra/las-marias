using System;
using System.Text.Json.Serialization;

using HotChocolate;

// a little cheat ;)
namespace Orun.Domain
{
    /// <inheritdoc cref="IBusinessEntity{TKey}"/>
    public class BusinessEntity<TKey> : IBusinessEntity<TKey>
    {
        /// <summary>
        /// return a new instance of <see cref="BusinessEntity{TKey}"/>
        /// </summary>
        public BusinessEntity()
        {
            Deleted = false;
            CreatedAt = DateTime.UtcNow;
            RowVersion = Guid.NewGuid().ToString();
        }

        /// <inheritdoc cref="IBusinessEntity{TKey}.Deleted"/>
        [GraphQLIgnore] // do not show in grahql
        public bool Deleted { get; set; }
        
        /// <inheritdoc cref="IBusinessEntity{TKey}.CreatedAt"/>
        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
        
        /// <inheritdoc cref="IBusinessEntity{TKey}.UpdatedAt"/>
        [JsonPropertyName("updateAt")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <inheritdoc cref="IBusinessEntity{TKey}.DeletedAt"/>
        public DateTimeOffset? DeletedAt { get; set; }

        /// <inheritdoc cref="IBusinessEntity{TKey}.RowVersion" />
        [JsonPropertyName("rowVersion")]
        public string RowVersion{ get; set; }
    }
}