using NovelCraft.Sdk;

Console.WriteLine("Enter the host:");
var host = Console.ReadLine()?? "localhost";

Console.WriteLine("Enter the port:");
var port = int.Parse(Console.ReadLine() ?? "14514");

Sdk.Initialize(new() {
  Host = host,
  Name = "Steve",
  Port = port,
  Token = "0123456789abcdef"
});

while (true) {
  if (Sdk.Latency is not null) {
    Sdk.Logger.Info($"Latency: {Sdk.Latency?.TotalMilliseconds}ms");
  }
  
  // Sleep for 1 second
  Thread.Sleep(1000);
}