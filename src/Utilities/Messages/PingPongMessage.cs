using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {


  internal record ClientPingMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.Ping;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("sent_time")]
    public decimal SentTime { get; init; }
  }

  internal record ServerPongMessage : MessageBase {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.Ping;

    [JsonPropertyName("sent_time")]
    public decimal SentTime { get; init; }
  }
}