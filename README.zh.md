# NovelCraft SDK (.NET)

如果你只想浏览一下API文档，你可以这样做[这里](https://novelcraft.github.io/SDK-DotNet/en/annotated.html)。

## 简介

NovelCraft SDK for .NET是一个.NET库，允许开发者为NovelCraft创建代理，这是一个可扩展的开源沙盒平台，灵感来自Minecraft。通过NovelCraft SDK for .NET，开发者可以访问各种功能来控制代理的行动、感知和与环境的互动。该SDK还支持开放世界中的新奇事物检测和发现，其中新奇的物体会影响游戏的进行。NovelCraft SDK for .NET被设计成易于使用并与现有的C项目整合。它兼容于Windows、Linux和Mac OS平台。NovelCraft SDK for .NET是为NovelCraft开发新颖和创造性代理的强大工具。

## 安装

由于SDK是一个标准的.NET类库，你可以通过在`src/Sdk.csproj`文件中添加一个引用来轻松地将其添加到你的项目中。

你也可以通过运行以下命令从NuGet安装SDK。

```bash
dotnet add package NovelCraft.Sdk
```

这样，你就可以在你的代码中访问SDK所定义的所有函数和类型。SDK还在samples文件夹中提供了一些NovelCraft的代理实例。你可以运行它们，看看它们是如何工作的，并根据你的需要修改它们。要运行一个例子，你需要在你的机器上安装NovelCraft并运行NovelCraft服务器。SDK还附带了一份文档，解释了如何使用其功能，以及如何针对不同的场景进行定制。

## 使用方法

### 初始化

在使用SDK之前，你需要通过配置来初始化SDK。配置中指定了SDK的一些参数，如NovelCraft服务器的IP地址和端口，以及代理的标记。你可以使用`Sdk.Initialize()`函数用配置结构来初始化SDK。配置结构是一个记录，其中有每个参数的字段。如果你想动态地改变一些参数，你可以手动创建配置结构。初始化SDK后，代理将自动连接到NovelCraft服务器并开始接收游戏信息。

下面是一个例子。

```csharp
using NovelCraft.Sdk;

// 创建一个配置结构。
var config = new Config
{
    Host = "localhost"。
    Port = 14514。
    Token = "1145141919810"
}

Sdk.Initialize(config);
```

### 获取游戏信息

SDK提供了一些函数来获取游戏信息。你可以使用这些函数来查询游戏世界的状态，其中的对象，以及代理本身。例如，你可以使用`Sdk.Blocks`属性来获得一个包含游戏世界中的块的信息的世界结构。你可以使用`Sdk.Entities`属性来获得一个实体结构数组，其中包含游戏世界中每个实体的类型、位置、方向和属性的信息。你可以使用`Sdk.Agent`属性来获得一个代理结构，其中包含关于代理的名称、ID、位置、方向、健康、库存和行动的信息。

下面是一个例子。

```csharp
using NovelCraft.Sdk;

// 获取位置(0, 0, 0)的块。
Position<int> position = new (0, 0, 0);
var block = Sdk.Blocks[position];

// 获取ID为114的实体。
var entity = Sdk.Entities[114];
```

### 执行行动

通过代理API，你可以在游戏中执行动作。你可以使用这些API来控制你的代理人的移动、旋转和跳跃。你还可以使用这些API与游戏世界中的物体进行互动，如拾取、丢弃、放置、使用和制作物品。

下面是一个例子。

```csharp
using NovelCraft.Sdk;

// 前进
Sdk.Agent.SetMovement(IAgent.MovementKind.Forward);

// 看向 (0, 0, 0).
Position<decimal> position = new (0, 0, 0);
Sdk.Agent.LookAt(position);
```

## 接下来的步骤

要了解更多关于NovelCraft SDK for .NET的信息，你可以阅读API文档。你可以查看所有的API[这里](https://novelcraft.github.io/SDK-DotNet/en/annotated.html)。你也可以查看例子文件夹中的例子。你可以运行它们，看看它们是如何工作的，并修改它们以适应你的需要。