using CodingCat.Serializers.Abstracts;
using CodingCat.Serializers.Interfaces;

namespace CodingCat.Serializers.Impls
{
    public class Int32Serializer : ToStringSerializer<int>
    {
        #region Constructor(s)

        public Int32Serializer() : base(new StringSerializer())
        {
        }

        public Int32Serializer(ToStringSerializer<int> serializer)
            : base(serializer) { }

        #endregion Constructor(s)

        public Int32Serializer WithSerializer(
            ISerializer<string> serializer
        )
        {
            return new Int32Serializer(this)
            {
                StringSerializer = serializer
            };
        }

        public override int Deserialize(string body) => int.Parse(body);

        public override string Serialize(int input) => input.ToString();
    }
}