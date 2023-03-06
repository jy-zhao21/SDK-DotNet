namespace NovelCraft.Sdk;

public interface IItemStack {
  /// <summary>
  /// Gets the count of the item stack.
  /// </summary>
  public int Count { get; }

  /// <summary>
  /// Gets the type of the item stack.
  /// </summary>
  public int TypeId { get; }
}