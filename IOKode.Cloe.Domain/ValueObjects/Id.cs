namespace IOKode.Cloe.Domain.ValueObjects
{
    public record Id<TEntity>
    {
        public string Value { get; }

        public Id(string value)
        {
            Value = value;
        }
    }
}