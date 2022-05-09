using Newtonsoft.Json;
using System.Text.Json;

namespace NaTour2021_API.Utils
{
    public class JsonTimestampConverter : System.Text.Json.Serialization.JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {

                if (jsonDoc.RootElement.GetRawText() != null)
                {

                    var timeSpanString = jsonDoc.RootElement.GetRawText();
                    Dictionary<string, int> timespanDict =
                        JsonConvert.DeserializeObject<Dictionary<string, int>>(timeSpanString);

                    TimeSpan timeSpan = new TimeSpan(days: timespanDict.GetValueOrDefault("days"), hours: timespanDict.GetValueOrDefault("hours"), minutes: timespanDict.GetValueOrDefault("minutes"), seconds: 0);

                    return timeSpan;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }

        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {

            Dictionary<String, int> timeSpanDict = new Dictionary<string, int>();
            timeSpanDict.Add("days", value.Days);
            timeSpanDict.Add("hours", value.Hours);
            timeSpanDict.Add("minutes", value.Minutes);

            writer.WriteStringValue(JsonConvert.SerializeObject(timeSpanDict));
        }
    }
}
