using NovelCraft.Sdk.Messages;

namespace NovelCraft.Sdk;

internal class Agent : Entity, IAgent {
  public IInventory Inventory => _inventory;

  public IAgent.MovementKind? Movement {
    get => _movement;
    set {
      if (value is null) {
        _movement = null;
        return;
      }

      ClientPerformMoveMessage message = new() {
        Token = Token,
        DirectionType = value switch {
          IAgent.MovementKind.Forward => ClientPerformMoveMessage.Direction.Forward,
          IAgent.MovementKind.Backward => ClientPerformMoveMessage.Direction.Backward,
          IAgent.MovementKind.Left => ClientPerformMoveMessage.Direction.Left,
          IAgent.MovementKind.Right => ClientPerformMoveMessage.Direction.Right,
          null => ClientPerformMoveMessage.Direction.Stop,
          _ => throw new NotImplementedException()
        }
      };

      Sdk.Client?.Send(message);
      _movement = value;
    }
  }

  public string Token { get; }

  private Inventory _inventory = new();
  private IAgent.MovementKind? _movement = null;


  public Agent(string token, int uniqueId, IPosition<decimal> position,
    IOrientation orientation) : base(uniqueId, 0, position, orientation) {
    Token = token;
  }


  public void Attack(IAgent.InteractionKind kind) {
    // TODO
  }

  public void Jump() {
    ClientPerformJumpMessage message = new() {
      Token = Token
    };

    Sdk.Client?.Send(message);
  }

  public void LookAt(IPosition<decimal> position) {
    // TODO
  }

  public void SetMovement(IAgent.MovementKind? kind) {
    // TODO
  }

  public void Use(IAgent.InteractionKind kind) {
    ClientPerformUseMessage message = new() {
      Token = Token,
      UseType = kind switch {
        IAgent.InteractionKind.Click => ClientPerformUseMessage.UseKind.UseClick,
        IAgent.InteractionKind.HoldStart => ClientPerformUseMessage.UseKind.UseStart,
        IAgent.InteractionKind.HoldEnd => ClientPerformUseMessage.UseKind.UseEnd,
        _ => throw new NotImplementedException()
      }
    };

    Sdk.Client?.Send(message);
  }
}