using System.Text.Json.Serialization;

namespace dotnet_game.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3,
        Healer = 4,
    }
}