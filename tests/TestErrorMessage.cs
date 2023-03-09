using System.Text.Json.Nodes;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk.Tests;

public class TestErrorMessage {
  [Fact]
  public void TestDeserializationAndSerialization() {
    const string jsonStr = @"{
      ""bound_to"": 1,
      ""type"": 200,
      ""code"": 1,
      ""message"": ""test""
    }";

    var json = JsonNode.Parse(jsonStr);

    var msg = Parser.Parse(json!);

    var result = msg.Json;

    Assert.Equal(json!.ToJsonString(), result.ToJsonString());
  }
}