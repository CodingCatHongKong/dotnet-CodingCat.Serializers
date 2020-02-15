using CodingCat.Serializers.Abstracts;
using CodingCat.Serializers.Interfaces;

namespace CodingCat.Serializers.Impls
{
    public class Int16Serializer : ToStringSerializer<short>
    {
        #region Constructor(s)

        public Int16Serializer() : base(new StringSerializer())
        {
        }

        public Int16Serializer(ToStringSerializer<short> serializer)
            : base(serializer) { }

        #endregion Constructor(s)

        public Int16Serializer WithSerializer(
            ISerializer<string> serializer
        )
        {
            return new Int16Serializer(this)
            {
                StringSerializer = serializer
            };
        }

        public override short Deserialize(string body) => short.Parse(body);

        public override string Serialize(short input) => input.ToString();
    }
}