using NovelCraft.Sdk;

Console.Write("Enter the host: ");
string host = Console.ReadLine()!;

Console.Write("Enter the port: ");
int port = int.Parse(Console.ReadLine()!);

Console.Write("Enter the token: ");
string token = Console.ReadLine()!;

Sdk.Initialize(new() {
  Host = host,
  Port = port,
  Token = token
});

while (true) {
  if (Sdk.Agent is not null) {
    Sdk.Logger.Info(
      $"Inventory content: {string.Join(", ", Enumerable.Range(0, Sdk.Agent.Inventory.Size).Select(i => Sdk.Agent.Inventory[i]?.TypeId ?? 0))}");
    Sdk.Logger.Info($"Inventory hot bar size: {Sdk.Agent.Inventory.HotBarSize}");
    Sdk.Logger.Info($"Inventory main hand slot: {Sdk.Agent.Inventory.MainHandSlot}");
    Sdk.Logger.Info($"Inventory size: {Sdk.Agent.Inventory.Size}");

    Sdk.Logger.Info($"Movement: {Sdk.Agent.Movement}");
    Sdk.Logger.Info($"Token: {Sdk.Agent.Token}");
  }

  if (Sdk.Blocks is not null) {
    Sdk.Logger.Info(
      $"Some blocks: {Sdk.Blocks[new Position<int>(0, 0, 0)]?.TypeId}, {Sdk.Blocks[new Position<int>(0, 1, 0)]?.TypeId}");
  }

  if (Sdk.Entities is not null) {
    Sdk.Logger.Info($"All entities: {Sdk.Entities.GetAllEntities().Select(e => e.UniqueId)}");
  }

  if (Sdk.Tick is not null) {
    Sdk.Logger.Info($"Tick: {Sdk.Tick}");
  }

  if (Sdk.TicksPerSecond is not null) {
    Sdk.Logger.Info($"Ticks per second: {Sdk.TicksPerSecond}");
  }

  // Sleep for 1 second
  Thread.Sleep(1000);
}

struct Position<T> : IPosition<T> {
  public T X { get; set; }
  public T Y { get; set; }
  public T Z { get; set; }

  public Position(T x, T y, T z) {
    X = x;
    Y = y;
    Z = z;
  }
}