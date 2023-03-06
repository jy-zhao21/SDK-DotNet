namespace NovelCraft.Sdk;

public interface IEntity {
  public IOrientation Orientation { get; }
  public IPosition<decimal> Position { get; }
  public int TypeId { get; }
  public int UniqueId { get; }
}