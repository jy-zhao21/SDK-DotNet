using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal abstract record MessageBase {
  public enum MessageKind {
    Error, GetBlocksAndEntities, GetPlayerInfo, Handshake
  }

  public enum BoundToKind { ServerBound, ClientBound }


  [JsonIgnore]
  public abstract JsonNode Json { get; }

  [JsonPropertyName("bound_to")]
  public abstract BoundToKind BoundTo { get; }

  [JsonPropertyName("type")]
  public abstract MessageKind Type { get; }
}
