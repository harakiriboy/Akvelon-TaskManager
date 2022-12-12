using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Akvelon_Task_Manager.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        private string dateFormat = "dd/MM/yyyy";  // Setting up how datetime object format to be displayed
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParseExact(reader.GetString(), dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;   // Parsing datetime object and applying to its newly defined format
            }
            throw new JsonException("A datetime property is not in a proper format.");  // Throw exception when datetime created with wrong signature
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(dateFormat));
        }
    }
}