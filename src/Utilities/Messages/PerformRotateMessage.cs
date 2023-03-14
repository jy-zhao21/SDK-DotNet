using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {


  internal record ClientPerformRotateMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformRotate;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("orientation")]
    public Orientation Orientation { get; init; } = new();
  }
}