
using System.Text.Json.Serialization;
using katori.Enums;

namespace katori.Dto;

public class LedgerDto
{
    public string Title { get; set; } = "";
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public LedgerTypes LedgerType { get; set; }

}
