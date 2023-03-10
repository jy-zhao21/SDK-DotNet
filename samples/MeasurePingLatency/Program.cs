using NovelCraft.Sdk;

Sdk.Initialize(new() {
  Host = "localhost",
  Name = "Steve",
  Port = 14514,
  Token = "0123456789abcdef"
});

while (true) {
  if (Sdk.Latency is not null) {
    Sdk.Logger.Info($"Latency: {Sdk.Latency?.TotalMilliseconds}ms");
  }
  
  // Sleep for 1 second
  Thread.Sleep(1000);
}