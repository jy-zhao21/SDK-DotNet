using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {

  internal record ServerAfterBlockChangeMessage : MessageBase {
    public record ChangeType {
      [JsonPropertyName("position")]
      public Position<int> Position { get; init; } = new();

      [JsonPropertyName("block_type_id")]
      public int BlockTypeId { get; init; }
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.AfterBlockChange;

    [JsonPropertyName("change_list")]
    public List<ChangeType> ChangeList { get; init; } = new();
  }
}