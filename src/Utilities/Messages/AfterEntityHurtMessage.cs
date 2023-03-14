using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterEntityHurtMessage : MessageBase {
    public record HurtType {
      [JsonPropertyName("victim_unique_id")]
      public int VictimUniqueId { get; init; }

      [JsonPropertyName("damage")]
      public decimal Damage { get; init; }

      [JsonPropertyName("health")]
      public decimal? Health { get; init; }

      [JsonPropertyName("is_dead")]
      public bool? IsDead { get; init; }
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterEntityHurt;

    [JsonPropertyName("hurt_list")]
    public List<HurtType> HurtList { get; init; } = new();
  }
}