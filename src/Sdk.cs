using NovelCraft.Utilities.Logger;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk;

/// <summary>
/// The SDK.
/// </summary>
public static partial class Sdk {
  private const int TimerInterval = 1000;


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
  public static IClient? Client { get; private set; } = null;

  /// <summary>
  /// Gets the list of all entities in the world.
  /// </summary>
  public static IEntitySource? Entities { get; private set; } = null;

  /// <summary>
  /// Gets the logger.
  /// </summary>
  public static ILogger Logger { get; } = new Logger("User");

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

  internal static ILogger _sdkLogger { get; } = new Logger("SDK");
  private static (int LastTick, DateTime LastTickTime)? _lastTickInfo = null;
  private static System.Timers.Timer _timer = new(TimerInterval);
  private static string? _token = null;


  /// <summary>
  /// Initializes the SDK.
  /// </summary>
  /// <param name="config">The configuration of the SDK.</param>
  public static void Initialize(Config config) {
    _sdkLogger.Info("Initializing SDK...");

    _token = config.Token;

    // Initialize the client
    Client = new Client(config.Host, config.Port);
    Client.AfterMessageReceiveEvent += OnAfterMessageReceiveEvent;

    // Initialize the timer.
    _timer.Elapsed += (sender, e) => OnTick();
    OnTick(); // Manually call the tick event to get information right away.
    _timer.Start();
  }

  private static void OnAfterMessageReceiveEvent(object? sender, IMessage message) {
    switch (message) {
      case ErrorMessage msg:
        _sdkLogger.Error($"The server returned an error: {msg.Message} ({msg.Code})");
        break;

      case ServerGetBlocksAndEntitiesMessage msg:
        BlockSource blocks = new();
        foreach (var section in msg.Sections) {
          blocks.AddSection(
            new Section(
              new Position<int>(section.Position.X, section.Position.Y, section.Position.Z),
              section.Blocks
            )
          );
        }
        Blocks = blocks;

        EntitySource entities = new();
        foreach (var entity in msg.Entities) {
          entities[entity.UniqueId] = new Entity(entity.UniqueId, entity.TypeId,
            new Position<decimal>(entity.Position.X, entity.Position.Y, entity.Position.Z),
            new Orientation(entity.Orientation.Yaw, entity.Orientation.Pitch));
        }
        Entities = entities;
        break;

      case ServerGetPlayerInfoMessage msg:
        // TODO
        break;

      case ServerGetTickMessage serverGetTickMessage:
        _lastTickInfo = (serverGetTickMessage.Tick, DateTime.Now);
        TicksPerSecond = serverGetTickMessage.TicksPerSecond;
        break;
    }
  }

  private static void OnTick() {
    _sdkLogger.Info("Getting game information...");

    string token = _token ?? throw new InvalidOperationException("The SDK is not initialized.");

    Client?.Send(new ClientGetTickMessage() {
      Token = token
    });

    Client?.Send(new ClientGetBlocksAndEntitiesMessage() {
      Token = token
    });

    Client?.Send(new ClientGetPlayerInfoMessage() {
      Token = token
    });
  }
}