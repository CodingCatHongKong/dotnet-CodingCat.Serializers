using CodingCat.Serializers.Interfaces;
using System.Text;

namespace CodingCat.Serializers.Impls
{
    public class StringSerializer : ISerializer<string>
    {
        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public StringSerializer WithEncoding(Encoding encoding)
        {
            return new StringSerializer()
            {
                Encoding = encoding
            };
        }

        public byte[] ToBytes(string input) => this.Encoding.GetBytes(input);

        public string FromBytes(byte[] bytes) => this.Encoding.GetString(bytes);
    }
}