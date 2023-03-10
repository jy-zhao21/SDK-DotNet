using NovelCraft.Sdk;

Console.Write("Enter the host: ");
string host = Console.ReadLine()!;

Console.Write("Enter the port: ");
int port = int.Parse(Console.ReadLine()!);

Console.Write("Enter the token: ");
string token = Console.ReadLine()!;

Sdk.Initialize(new() {
  Host = host,
  Name = "Steve",
  Port = port,
  Token = token
});

while (true) {
  if (Sdk.Latency is not null) {
    Sdk.Logger.Info($"Latency: {Sdk.Latency?.TotalMilliseconds}ms");
  }
  
  // Sleep for 1 second
  Thread.Sleep(1000);
}