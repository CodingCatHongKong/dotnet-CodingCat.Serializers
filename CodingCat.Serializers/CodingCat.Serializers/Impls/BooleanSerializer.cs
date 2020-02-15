using CodingCat.Serializers.Abstracts;
using CodingCat.Serializers.Interfaces;

namespace CodingCat.Serializers.Impls
{
    public class BooleanSerializer : ToStringSerializer<bool>
    {
        #region Constructor(s)

        public BooleanSerializer() : base(new StringSerializer())
        {
        }

        public BooleanSerializer(ToStringSerializer<bool> serializer)
            : base(serializer) { }

        #endregion Constructor(s)

        public BooleanSerializer WithSerializer(
            ISerializer<string> serializer
        )
        {
            return new BooleanSerializer(this)
            {
                StringSerializer = serializer
            };
        }

        public override bool Deserialize(string body) => bool.Parse(body);

        public override string Serialize(bool input) => input.ToString();
    }
}