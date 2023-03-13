using System.Text.Json;

namespace Calendar_api.Utilities
{
    public static class Utilities
    {
        public static JsonSerializerOptions JsonCaseInsensitiveDesirializeOption = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static JsonSerializerOptions JsonCaseLowerCaseSerializeOption = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static int workCalendarId = 1;
    }
}
