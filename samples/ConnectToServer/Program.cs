using NovelCraft.Sdk;

Sdk.Initialize(new(){
    Host = "localhost",
    Name = "Steve",
    Port = 14514,
    Token = "0123456789abcdef"
});

Sdk.Logger.Info($"TPS: {Sdk.TicksPerSecond}");

Sdk.Logger.Info($"Tick: {Sdk.Tick}");