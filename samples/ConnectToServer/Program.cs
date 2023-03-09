using NovelCraft.Sdk;

Sdk.Initialize(new() {
  Host = "localhost",
  Name = "Steve",
  Port = 14514,
  Token = "0123456789abcdef"
});

while (true) {
  Sdk.Logger.Info($"TPS: {Sdk.TicksPerSecond}");
  Sdk.Logger.Info($"Tick: {Sdk.Tick}");
  
  // Sleep for 1 second
  Thread.Sleep(1000);
}