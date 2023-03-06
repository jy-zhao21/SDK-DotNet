using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal record PositionType<T> {
  [JsonPropertyName("x")]
  public required T X { get; init; }

  [JsonPropertyName("y")]
  public required T Y { get; init; }

  [JsonPropertyName("z")]
  public required T Z { get; init; }
}