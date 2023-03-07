namespace NovelCraft.Sdk;

public static partial class Sdk {
  internal static NovelCraft.Utilities.ILogger _sdkLogger { get; } = new NovelCraft.Utilities.Logger("SDK");

  private static (int LastTick, DateTime LastTickTime)? _lastTickInfo = null;
}