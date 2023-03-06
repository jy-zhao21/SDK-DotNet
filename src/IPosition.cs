namespace NovelCraft.Sdk;

public interface IPosition<T> {
  public T X { get; }
  public T Y { get; }
  public T Z { get; }
}