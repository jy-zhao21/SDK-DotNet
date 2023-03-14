using System.Text.Json.Serialization;

namespace NovelCraft.Utilities.Messages {



  internal record ClientGetBlocksAndEntitiesMessage : MessageBase, IClientMessage {
    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ServerBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetBlocksAndEntities;

    [JsonPropertyName("token")]
    public string Token { get; init; } = string.Empty;

    [JsonPropertyName("request_section_list")]
    public List<Position<int>> RequestSectionList { get; init; } = new();
  }


  internal record ServerGetBlocksAndEntitiesMessage : MessageBase {
    public record SectionType {
      [JsonPropertyName("position")]
      public Position<int> Position { get; init; } = new();

      [JsonPropertyName("blocks")]
      public List<int> Blocks { get; init; } = new();
    }

    public record EntityType {
      [JsonPropertyName("type_id")]
      public int TypeId { get; init; }

      [JsonPropertyName("unique_id")]
      public int UniqueId { get; init; }

      [JsonPropertyName("position")]
      public Position<decimal> Position { get; init; } = new();

      [JsonPropertyName("orientation")]
      public Orientation Orientation { get; init; } = new();
    }


    [JsonPropertyName("bound_to")]
    public override IMessage.BoundToKind BoundTo => IMessage.BoundToKind.ClientBound;

    [JsonPropertyName("type")]
    public override IMessage.MessageKind Type => IMessage.MessageKind.GetBlocksAndEntities;

    [JsonPropertyName("sections")]
    public List<SectionType> Sections { get; init; } = new();

    [JsonPropertyName("entities")]
    public List<EntityType> Entities { get; init; } = new();
  }
}