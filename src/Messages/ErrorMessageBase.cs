using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;

internal abstract record ErrorMessageBase : MessageBase {
  [JsonPropertyName("type")]
  public override MessageKind Type => MessageKind.Error;

  [JsonPropertyName("code")]
  public abstract required int Code { get; init; }

  [JsonPropertyName("message")]
  public abstract required string Message { get; init; }
}