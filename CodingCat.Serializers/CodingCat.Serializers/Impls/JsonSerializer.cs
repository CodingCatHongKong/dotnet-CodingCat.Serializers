using CodingCat.Serializers.Abstracts;
using CodingCat.Serializers.Interfaces;
using Newtonsoft.Json;

namespace CodingCat.Serializers.Impls
{
    public class JsonSerializer<T> : ToStringSerializer<T>
    {
        public JsonSerializerSettings Settings { get; set; }

        #region Constructor(s)

        public JsonSerializer() : base(new StringSerializer())
        {
        }

        public JsonSerializer(JsonSerializer<T> serializer)
            : base(serializer)
        {
            this.Settings = serializer.Settings;
        }

        #endregion Constructor(s)

        public JsonSerializer<T> WithSetting(
            JsonSerializerSettings settings
        )
        {
            return new JsonSerializer<T>(this) { Settings = settings };
        }

        public JsonSerializer<T> WithSerializer(
            ISerializer<string> serializer
        )
        {
            return new JsonSerializer<T>(this)
            {
                StringSerializer = serializer
            };
        }

        public override string Serialize(T input)
        {
            if (this.Settings == null)
                return JsonConvert.SerializeObject(input);

            return JsonConvert.SerializeObject(input, this.Settings);
        }

        public override T Deserialize(string body)
        {
            if (this.Settings == null)
                return JsonConvert.DeserializeObject<T>(body);

            return JsonConvert
                .DeserializeObject<T>(body, this.Settings);
        }
    }
}