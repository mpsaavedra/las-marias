using System;
using System.Text.Json.Serialization;

// a little cheat ;)
namespace Orun.Domain
{
    /// <summary>
    /// Define the data of a trackable entity in the system. It adds
    /// two new properties to the entity:
    /// <li><see cref="IBusinessEntity{TKey}.Deleted"></see></li>
    /// </summary>
    public interface IBusinessEntity<TKey>
    {
        /// <summary>
        /// Mark entity as soft deleted
        /// </summary>
        [JsonPropertyName("deleted")]
        bool Deleted{get;set;}
        
        /// <summary>
        /// creation date
        /// </summary>
        [JsonPropertyName("createdAt")]
        DateTimeOffset CreatedAt { get; set; }
        
        /// <summary>
        /// last modification date
        /// </summary>
        [JsonPropertyName("updateAt")]
        DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// when the entity was soft deleted
        /// </summary>
        [JsonPropertyName("deletedAt")]
        DateTimeOffset? DeletedAt { get; set; }

        /// <summary>
        /// Version to avoid possible mismatch
        /// </summary>
        string RowVersion{ get; set; }
    }
}