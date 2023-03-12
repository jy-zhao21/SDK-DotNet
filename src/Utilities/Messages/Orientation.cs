using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages;


public record Orientation : IOrientation {
  [JsonPropertyName("yaw")]
  public required decimal Yaw { get; init; }

  [JsonPropertyName("pitch")]
  public required decimal Pitch { get; init; }
}