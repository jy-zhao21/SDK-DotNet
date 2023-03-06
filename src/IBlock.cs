namespace NovelCraft.Sdk;

public interface IBlock {
  /// <summary>
  /// Gets the position of the block.
  /// </summary>
  public IPosition<int> Position { get; }

  /// <summary>
  /// Gets the type of the block.
  /// </summary>
  public int TypeId { get; }
}