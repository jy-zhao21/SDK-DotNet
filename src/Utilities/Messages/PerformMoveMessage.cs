using System.Text.Json.Serialization;
namespace NovelCraft.Utilities.Messages {


  internal record ClientPerformMoveMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformMove;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;
    public enum Direction {
      Stop,
      Forward,
      Backward,
      Left,
      Right
    }
    [JsonPropertyName("direction")]
    public Direction DirectionType { get; init; }
  }
}