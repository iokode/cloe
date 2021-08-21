namespace IOKode.Cloe.Domain
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