using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {


  public record Orientation : IOrientation {
    [JsonPropertyName("yaw")]
    public decimal Yaw { get; init; }

    [JsonPropertyName("pitch")]
    public decimal Pitch { get; init; }
  }
}