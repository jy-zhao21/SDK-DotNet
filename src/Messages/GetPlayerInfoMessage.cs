using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientGetPlayerInfoMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.GetPlayerInfo;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }
}


internal record ServerGetPlayerInfoMessage : MessageBase {

  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.GetPlayerInfo;

  // HP,EXP,Orientation,Position,MainHand,Inventory
}