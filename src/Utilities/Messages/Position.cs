using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {


  public record Position<T> : IPosition<T> {
    [JsonPropertyName("x")]
    public T X { get; init; } = default!;

    [JsonPropertyName("y")]
    public T Y { get; init; } = default!;

    [JsonPropertyName("z")]
    public T Z { get; init; } = default!;
  }
}