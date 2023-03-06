using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal record GetBlocksAndEntitiesMessageClientBound : MessageBase {
  public record SectionType {
    [JsonPropertyName("position")]
    public required PositionType<int> Position { get; init; }

    [JsonPropertyName("blocks")]
    public required List<int> Blocks { get; init; }
  }

  public record EntityType {
    [JsonPropertyName("type_id")]
    public required int TypeId { get; init; }

    [JsonPropertyName("unique_id")]
    public required string UniqueId { get; init; }

    [JsonPropertyName("position")]
    public required PositionType<decimal> Position { get; init; }

    [JsonPropertyName("orientation")]
    public required OrientationType Orientation { get; init; }
  }


  [JsonIgnore]
  public override JsonNode Json => JsonNode.Parse(JsonSerializer.Serialize(this))!;

  [JsonPropertyName("bound_to")]
  public override BoundToKind BoundTo => BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override MessageKind Type => MessageKind.GetBlocksAndEntities;

  [JsonPropertyName("sections")]
  public required List<SectionType> Sections { get; init;}
}