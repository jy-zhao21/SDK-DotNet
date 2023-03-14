using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientPerformAttackMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.PerformAttack;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    public enum AttackType {
      AttackClick,
      HoldStart,
      HoldEnd
    };

    [JsonPropertyName("attack_kind")]
    public AttackType AttackKind { get; init; }


  }
}