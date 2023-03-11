using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace NovelCraft.Sdk;

/// <summary>
/// Represents the configuration of the SDK.
/// </summary>
public record class Config {
  /// <summary>
  /// The IP address or host name of the server.
  /// </summary>
  [JsonPropertyName("host")]
  public required string Host { get; init; }

  /// <summary>
  /// The port of the server.
  /// </summary>
  [JsonPropertyName("port")]
  public required int Port { get; init; }

  /// <summary>
  /// The token of the client.
  /// </summary>
  [JsonPropertyName("token")]
  public required string Token { get; init; }

  /// <summary>
  /// Gets the JSON representation of the configuration.
  /// </summary>
  [JsonIgnore]
  public JsonNode Json {
    get => JsonNode.Parse(JsonSerializer.Serialize((object)this))!;
  }
}