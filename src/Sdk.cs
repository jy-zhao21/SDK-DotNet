using NovelCraft.Utilities.Logger;
using NovelCraft.Utilities.Messages;

namespace NovelCraft.Sdk;

/// <summary>
/// The SDK.
/// </summary>
public static partial class Sdk {
  private const int GetInfoInterval = 10000;
  private const int PingInterval = 1000;


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
  /// Gets the latency between the client and the server.
  /// </summary>
  public static TimeSpan? Latency { get; private set; } = null;

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
      var ticksSinceLastTick = (int)((decimal)timeSinceLastTick.TotalSeconds * TicksPerSecond);

      return _lastTickInfo.Value.LastTick + ticksSinceLastTick;
    }
  }

  /// <summary>
  /// Gets the number of ticks per second.
  /// </summary>
  public static decimal? TicksPerSecond { get; private set; } = null;

  internal static ILogger _sdkLogger { get; } = new Logger("SDK");
  private static (int LastTick, DateTime LastTickTime)? _lastTickInfo = null;
  private static System.Timers.Timer _getInfoTimer = new(GetInfoInterval);
  private static System.Timers.Timer _pingTimer = new(PingInterval);
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

    // Manually call the tick event to get information right away.
    OnTick();

    // Initialize the timers.
    _getInfoTimer.Elapsed += (sender, e) => OnTick();
    _getInfoTimer.Start();

    _pingTimer.Elapsed += (sender, e) => {
      Client?.Send(new ClientPingMessage() {
        Token = _token ?? throw new InvalidOperationException("The SDK is not initialized."),
        SentTime = (decimal)DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
      });
    };
    _pingTimer.Start();
  }

  private static void OnAfterMessageReceiveEvent(object? sender, IMessage message) {
    switch (message) {
      case ServerPongMessage msg:
        Latency = TimeSpan.FromMilliseconds((double)(DateTime.Now.Ticks - (long)(msg.SentTime * TimeSpan.TicksPerMillisecond)) / TimeSpan.TicksPerMillisecond);
        break;

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
        Agent = new Agent(_token ?? throw new InvalidOperationException("The SDK is not initialized."), msg.UniqueId,
          new Position<decimal>(msg.Position.X, msg.Position.Y, msg.Position.Z),
          new Orientation(msg.Orientation.Yaw, msg.Orientation.Pitch));
        break;

      case ServerGetTickMessage serverGetTickMessage:
        _lastTickInfo = (serverGetTickMessage.Tick, DateTime.Now);
        TicksPerSecond = serverGetTickMessage.TicksPerSecond;
        break;
    }
  }

  private static void OnTick() {
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