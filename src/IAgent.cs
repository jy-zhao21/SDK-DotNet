namespace NovelCraft.Sdk;

/// <summary>
/// An agent is a player that can be controlled by an AI.
/// </summary>
public interface IAgent : IEntity {
  public enum InteractionKind { Click, HoldStart, HoldEnd }
  public enum MovementKind { Forward, Backward, Left, Right }

  /// <summary>
  /// Gets the inventory of the agent.
  /// </summary>
  public IInventory Inventory { get; }

  /// <summary>
  /// Gets or sets the movement of the agent.
  /// </summary>
  /// <remarks>
  /// Null means stopped.
  /// </remarks>
  public MovementKind? Movement { get; set; }

  /// <summary>
  /// Gets or sets the orientation of the agent.
  /// </summary>
  public new IOrientation Orientation { get; set; }

  /// <summary>
  /// Gets the token of the agent.
  /// </summary>
  public string Token { get; }

  /// <summary>
  /// Performs an attack.
  /// </summary>
  /// <param name="kind">The kind of attack to perform.</param>
  public void Attack(InteractionKind kind);

  /// <summary>
  /// Performs a jump.
  /// </summary>
  public void Jump();

  /// <summary>
  /// Sets the movement of the agent.
  /// </summary>
  /// <param name="kind">The kind of movement to perform. Null means stopped.</param>
  public void SetMovement(MovementKind? kind);

  /// <summary>
  /// Performs a use action.
  /// </summary>
  /// <param name="kind">The kind of use action to perform.</param>
  public void Use(InteractionKind kind);
}