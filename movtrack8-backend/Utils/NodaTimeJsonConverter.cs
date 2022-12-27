using NodaTime;
using NodaTime.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace movtrack8_backend.Utils
{
    public class NodaTimeJsonConverter : JsonConverter<Instant>
    {
        public override Instant Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var res = InstantPattern.General.Parse(reader.GetString()!);
            if (res.Success)
            {
                return res.Value;
            }
            else
            {
                throw new JsonException(res.Exception.ToString());
            }
        }

        public override void Write(Utf8JsonWriter writer, Instant value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
