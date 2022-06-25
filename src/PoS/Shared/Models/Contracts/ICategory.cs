namespace LasMarias.PoS.Shared.Models.Abstractions;

using Orun.Domain;

public interface ICategory : IBusinessEntity<long>
{
    long CategoryId { get; set; }

    string Name { get; set; }

    bool Enable { get; set; }

    ICategory Parent { get; set; }
}