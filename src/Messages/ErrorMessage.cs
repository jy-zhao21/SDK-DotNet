using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientErrorMessage : MessageBase, IClientMessage, IErrorMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.Error;

  [JsonPropertyName("code")]
  public required int Code { get; init; }

  [JsonPropertyName("message")]
  public required string Message { get; init; }

  [JsonPropertyName("token")]
  public required string? Token { get; init; }
}


internal record ServerErrorMessage : MessageBase, IErrorMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.Error;

  [JsonPropertyName("code")]
  public required int Code { get; init; }

  [JsonPropertyName("message")]
  public required string Message { get; init; }
}