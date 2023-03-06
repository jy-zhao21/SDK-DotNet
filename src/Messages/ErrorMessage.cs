using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal record ErrorMessageClientBound : ErrorMessageBase {
  [JsonIgnore]
  public override JsonNode Json => JsonNode.Parse(JsonSerializer.Serialize(this))!;

  [JsonPropertyName("bound_to")]
  public override BoundToKind BoundTo => BoundToKind.ClientBound;

  [JsonPropertyName("code")]
  public override required int Code { get; init; }

  [JsonPropertyName("message")]
  public override required string Message { get; init; }
}


internal record ErrorMessageServerBound : ErrorMessageBase {
  [JsonIgnore]
  public override JsonNode Json => JsonNode.Parse(JsonSerializer.Serialize(this))!;

  [JsonPropertyName("bound_to")]
  public override BoundToKind BoundTo => BoundToKind.ServerBound;

  [JsonPropertyName("code")]
  public override required int Code { get; init; }

  [JsonPropertyName("message")]
  public override required string Message { get; init; }
}