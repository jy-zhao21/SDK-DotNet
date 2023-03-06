namespace NovelCraft.Sdk;

internal class Agent : Entity, IAgent {
  public IInventory Inventory => _inventory;
  public IAgent.MovementKind? Movement { 
    get => _movement;
    set {
      // TODO
    }
  }
  public string Token { get; }

  private Inventory _inventory = new();
  private IAgent.MovementKind? _movement = null;


  public Agent(string token, int uniqueId): base(uniqueId, 0) {
    Token = token;
  }


  public void Attack(IAgent.InteractionKind kind) {
    // TODO
  }

  public void Jump() {
    // TODO
  }

  public void LookAt(IPosition<decimal> position) {
    // TODO
  }

  public void SetMovement(IAgent.MovementKind? kind) {
    // TODO
  }

  public void Use(IAgent.InteractionKind kind) {
    // TODO
  }
}