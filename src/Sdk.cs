namespace NovelCraft.Sdk;

/// <summary>
/// The SDK.
/// </summary>
public static class Sdk {
  /// <summary>
  /// Gets the agent representing the player controlled by the user.
  /// </summary>
  public static IAgent? Agent { get; private set; } = null;

  /// <summary>
  /// Gets the block collection.
  /// </summary>
  public static IBlockSource? Blocks { get; private set; } = null;

  /// <summary>
  /// Gets the client for sending and receiving messages directly to or from the server.
  /// </summary>
  public static Client.IClient? Client { get; private set; } = null;

  /// <summary>
  /// Gets the list of all entities in the world.
  /// </summary>
  public static List<IEntity>? Entities { get; } = null;

  /// <summary>
  /// Gets current tick.
  /// </summary>
  public static int? Tick {
    get {
      if (_lastTickInfo is null) {
        return null;
      }

      if (TicksPerSecond is null) {
        return _lastTickInfo.Value.LastTick;
      }

      var timeSinceLastTick = DateTime.Now - _lastTickInfo.Value.LastTickTime;
      var ticksSinceLastTick = (int)(timeSinceLastTick.TotalSeconds * TicksPerSecond);

      return _lastTickInfo.Value.LastTick + ticksSinceLastTick;
    }
  }

  /// <summary>
  /// Gets the number of ticks per second.
  /// </summary>
  public static int? TicksPerSecond { get; private set; } = null;

  private static (int LastTick, DateTime LastTickTime)? _lastTickInfo = null;


  /// <summary>
  /// Initializes the SDK.
  /// </summary>
  /// <param name="config">The configuration of the SDK.</param>
  public static void Initialize(Config config) {
    throw new NotImplementedException();
  }
}