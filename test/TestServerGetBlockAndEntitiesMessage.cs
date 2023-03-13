using System.Text.Json.Nodes;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk.Tests;

public class TestServerGetBlocksAndEntitiesMessage {
  [Fact]
  public void TestDeserializationAndSerialization() {
    const string jsonStr = @"
    {
      ""bound_to"": 1,
      ""type"": 300,
      ""sections"": [
        {
          ""position"": {
            ""x"": 0,
            ""y"": 0,
            ""z"": 0
          },
          ""blocks"": []
        },
        {
          ""position"": {
            ""x"": 0,
            ""y"": 0,
            ""z"": 1
          },
          ""blocks"": []
        }
      ],
      ""entities"": [
        {
          ""type_id"": 0,
          ""unique_id"": 1,
          ""position"": {
            ""x"": 0,
            ""y"": 0,
            ""z"": 0
          },
          ""orientation"": {
            ""yaw"": 0,
            ""pitch"": 0
          }
        },
        {
          ""type_id"": 0,
          ""unique_id"": 2,
          ""position"": {
            ""x"": 0,
            ""y"": 0,
            ""z"": 0
          },
          ""orientation"": {
            ""yaw"": 0,
            ""pitch"": 0
          }
        }
      ]
    }";

    var json = JsonNode.Parse(jsonStr);

    foreach (var section in (JsonArray)json!["sections"]!) {
      // 4096 numbers from 0 to 4095
      var arr = new JsonArray();
      for (int i = 0; i < 4096; i++) {
        arr.Add(i);
      }

      section!["blocks"] = arr;
    }

    var msg = Parser.Parse(json!);

    var result = msg.Json;

    Assert.Equal(json!.ToJsonString(), result.ToJsonString());
  }
}