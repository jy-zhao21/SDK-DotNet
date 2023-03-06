using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal record OrientationType {
  [JsonPropertyName("yaw")]
  public required decimal Yaw { get; init; }

  [JsonPropertyName("pitch")]
  public required decimal Pitch { get; init; }
}