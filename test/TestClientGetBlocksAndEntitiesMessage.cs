using System.Text.Json.Nodes;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk.Tests;

public class TestClientGetBlocksAndEntitiesMessage {
  [Fact]
  public void TestDeserializationAndSerialization() {
    const string jsonStr = @"
    {
      ""bound_to"": 0,
      ""type"": 300,
      ""token"": ""test"",
      ""request_section_list"": [
        {
          ""x"": 0,
          ""y"": 0,
          ""z"": 0
        },
        {
          ""x"": 1,
          ""y"": 1,
          ""z"": 1
        }
      ]
    }";

    var json = JsonNode.Parse(jsonStr);

    var msg = Parser.Parse(json!);

    var result = msg.Json;

    Assert.Equal(json!.ToJsonString(), result.ToJsonString());
  }
}