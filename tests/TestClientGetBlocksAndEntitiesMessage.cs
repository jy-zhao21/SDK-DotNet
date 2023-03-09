using System.Text.Json.Nodes;
using NovelCraft.Sdk.Messages;

namespace NovelCraft.Sdk.Tests;

public class TestClientGetBlocksAndEntitiesMessage {
  [Fact]
  public void TestDeserializationAndSerialization() {
    const string jsonStr = @"
    {
      ""bound_to"": 0,
      ""type"": 300,
      ""token"": ""test""
    }";

    var json = JsonNode.Parse(jsonStr);

    var msg = Parser.Parse(json!);

    var result = msg.Json;

    Assert.Equal(json!.ToJsonString(), result.ToJsonString());
  }
}