# NovelCraft SDK for .NET

If you would just like to browse the API documentation, you can do so [here](https://novelcraft.github.io/SDK-DotNet/en/annotated.html).

## Introduction

NovelCraft SDK for .NET is a .NET library that allows developers to create agents for NovelCraft, a scalable open source sandbox platform inspired by Minecraft. With NovelCraft SDK for .NET, developers can access various functions to control the agent’s actions, perceptions, and interactions with the environment. The SDK also supports novelty detection and discovery in open worlds, where novel objects can impact gameplay. NovelCraft SDK for .NET is designed to be easy to use and integrate with existing C projects. It is compatible with Windows, Linux, and Mac OS platforms. NovelCraft SDK for .NET is a powerful tool for developing novel and creative agents for NovelCraft.

## Installation

Since the SDK is a standard .NET class library, you can easily add it to your project by adding a reference to the `src/Sdk.csproj` file.

You can also install the SDK from NuGet by running the following command:

```bash
dotnet add package NovelCraft.Sdk
```

This way, you can access all the functions and types defined by the SDK in your code. The SDK also provides some examples of agents for NovelCraft in the samples folder. You can run them to see how they work and modify them to suit your needs. To run an example, you need to have NovelCraft installed on your machine and run NovelCraft server. The SDK also comes with a documentation that explains how to use its features and how to customize it for different scenarios.

## Usage

### Initialization

Before using the SDK, you need to initialize the SDK with configuration. The configuration specifies some parameters for the SDK, such as the IP address and port of the NovelCraft server, and the token of the agent. You can use `Sdk.Initialize()` function to initialize the SDK with a configuration structure. The configuration structure is a record that has fields for each parameter. You can create the configuration structure manually if you want to change some parameters dynamically. After initializing the SDK, the agent will automatically connect to the NovelCraft server and start receiving game information.

Here is an example:

```csharp
using NovelCraft.Sdk;

// Create a configuration structure.
var config = new Config
{
    Host = "localhost",
    Port = 14514,
    Token = "1145141919810"
}

Sdk.Initialize(config);
```

### Get game information

The SDK provides a number of functions to get game information. You can use these functions to query the state of the game world, the objects in it, and the agent itself. For example, you can use `Sdk.Blocks` property to get a world structure that contains information about the blocks of the game world. You can use `Sdk.Entities` property to get an array of entity structures that contain information about the type, position, orientation, and properties of each entity in the game world. You can use `Sdk.Agent` property to get an agent structure that contains information about the name, ID, position, orientation, health, inventory, and actions of your agent.

Here is an example:

```csharp
using NovelCraft.Sdk;

// Get the block at position (0, 0, 0).
Position<int> position = new (0, 0, 0);
var block = Sdk.Blocks[position];

// Get the entity with ID 114.
var entity = Sdk.Entities[114];
```

### Perform actions

With agent APIs, you can perform actions in the game. You can use these APIs to control the movement, rotation, and jumping of your agent. You can also use these APIs to interact with objects in the game world, such as picking up, dropping, placing, using, and crafting items.

Here is an example:

```csharp
using NovelCraft.Sdk;

// Move forward.
Sdk.Agent.SetMovement(IAgent.MovementKind.Forward);

// Look at position (0, 0, 0).
Position<decimal> position = new (0, 0, 0);
Sdk.Agent.LookAt(position);
```

## Next steps

To learn more about NovelCraft SDK for .NET, you can read the API documentation. You can check out all APIs [here](https://novelcraft.github.io/SDK-DotNet/en/annotated.html). You can also check out the examples in the examples folder. You can run them to see how they work and modify them to suit your needs.