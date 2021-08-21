namespace IOKode.Cloe.Domain.ValueObjects
{
    public record Markdown
    {
        public string Value { get; }

        public Markdown(string value)
        {
            Value = value;
        }
    }
}