namespace IOKode.Cloe.Domain
{
    public record Id<TEntity>
    {
        public string Value { get; init; }
    }
}