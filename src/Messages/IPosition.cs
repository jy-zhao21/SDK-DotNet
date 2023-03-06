namespace NovelCraft.Sdk.Messages;

public interface IPosition<T> {
  T X { get; init; }
  T Y { get; init; }
  T Z { get; init; }
}