using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientGetPlayerInfoMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetPlayerInfo;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;
  }


  internal record ServerGetPlayerInfoMessage : MessageBase {
    public record ItemStackType {
      [JsonPropertyName("type_id")]
      public int TypeId { get; init; }

      [JsonPropertyName("count")]
      public int Count { get; init; }
    }

    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetPlayerInfo;

    [JsonPropertyName("health")]
    public decimal Health { get; init; }

    [JsonPropertyName("orientation")]
    public Orientation Orientation { get; init; } = new();

    [JsonPropertyName("position")]
    public Position<decimal> Position { get; init; } = new();

    [JsonPropertyName("main_hand")]
    public int MainHand { get; init; }

    [JsonPropertyName("inventory")]
    public List<ItemStackType?> Inventory { get; init; } = new();

    [JsonPropertyName("unique_id")]
    public int UniqueId { get; init; }
  }
}