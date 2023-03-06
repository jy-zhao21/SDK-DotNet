namespace NovelCraft.Sdk;

internal struct Position<T> : IPosition<T> {
  public T X { get; set; }
  public T Y { get; set; }
  public T Z { get; set; }


  public Position(T x, T y, T z) {
    X = x;
    Y = y;
    Z = z;
  }
}