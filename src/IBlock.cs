namespace NovelCraft.Sdk;

public interface IBlock {
  public IPosition<int> Position { get; }
  public int TypeId { get; }
}