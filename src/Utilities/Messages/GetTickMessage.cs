using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientGetTickMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetTick;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;
  }


  internal record ServerGetTickMessage : MessageBase {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetTick;

    [JsonPropertyName("tick")]
    public int Tick { get; init; }

    [JsonPropertyName("ticks_per_second")]
    public decimal TicksPerSecond { get; init; }
  }
}