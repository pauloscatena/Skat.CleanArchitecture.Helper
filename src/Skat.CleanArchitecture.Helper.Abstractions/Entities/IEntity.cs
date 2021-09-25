namespace Skat.CleanArchitecture.Helper.Abstractions.Entities
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
