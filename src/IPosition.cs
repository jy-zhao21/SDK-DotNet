namespace NovelCraft.Sdk;

public interface IPosition<T> {
  public T X { get; set; }
  public T Y { get; set; }
  public T Z { get; set; }
}