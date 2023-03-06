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
  /// Gets the client for sending and receiving messages directly to or from the server.
  /// </summary>
  public static Client.IClient? Client { get; private set; } = null;

  /// <summary>
  /// Gets the list of all entities in the world.
  /// </summary>
  public static List<IEntity> Entities { get; } = new List<IEntity>();

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
  /// Gets the entity with the specified unique ID.
  /// </summary>
  /// <param name="uniqueId">The unique ID of the entity.</param>
  /// <returns>The entity with the specified unique ID. Null if no entity with the specified unique ID exists.</returns>
  public static IEntity? GetEntity(int uniqueId) => throw new NotImplementedException();

  /// <summary>
  /// Gets the block at the specified position.
  /// </summary>
  /// <param name="position">The position of the block.</param>
  /// <returns>The block at the specified position. Null if the section containing the block is not loaded.</returns>
  public static IBlock? GetBlockAt(IPosition<int> position) => throw new NotImplementedException();

  /// <summary>
  /// Initializes the SDK.
  /// </summary>
  /// <param name="config">The configuration of the SDK.</param>
  public static void Initialize(Config config) {
    throw new NotImplementedException();
  }
}