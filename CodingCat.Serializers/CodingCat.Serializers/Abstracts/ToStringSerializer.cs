using CodingCat.Serializers.Interfaces;

namespace CodingCat.Serializers.Abstracts
{
    public abstract class ToStringSerializer<T>
        : ISerializer<T>, ISerializer<T, string>
    {
        public ISerializer<string> StringSerializer { get; set; }

        #region Constructor(s)

        public ToStringSerializer(ISerializer<string> serializer)
        {
            this.StringSerializer = serializer;
        }

        public ToStringSerializer(ToStringSerializer<T> serializer)
            : this(serializer.StringSerializer)
        {
            this.StringSerializer = serializer.StringSerializer;
        }

        #endregion Constructor(s)

        public byte[] ToBytes(T input)
        {
            return this.StringSerializer
                .ToBytes(this.Serialize(input));
        }

        public T FromBytes(byte[] bytes)
        {
            return this.Deserialize(this.StringSerializer
                .FromBytes(bytes)
            );
        }

        public abstract string Serialize(T input);

        public abstract T Deserialize(string body);
    }
}