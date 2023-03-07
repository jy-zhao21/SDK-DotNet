using System.Text.Json.Serialization;

namespace NovelCraft.Sdk.Messages;


internal record ClientPerformAttackMessage : MessageBase, IClientMessage {
  [JsonPropertyName("bound_to")]
  public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

  [JsonPropertyName("type")]
  public override IMessage.MessageKind Type => IMessage.MessageKind.PerformAttack;

  [JsonPropertyName("token")]
  public required string? Token { get; init; }

  //   [JsonPropertyName("attack_kind")]
  //   public required AttackKind AttackKind { get; init; }
}