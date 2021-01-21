namespace Domain.ValueObjects
{
    public class Address
    {
        public string Value { get; }
        public Address(string value)
        {
            Value = value;
        }
    }
}
