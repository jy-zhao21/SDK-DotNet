namespace NovelCraft.Sdk;

internal struct Position<T> : IPosition<T> {
  public T X { get; set; }
  public T Y { get; set; }
  public T Z { get; set; }


  public Position(IPosition<T> position) {
    X = position.X;
    Y = position.Y;
    Z = position.Z;
  }

  public Position(T x, T y, T z) {
    X = x;
    Y = y;
    Z = z;
  }
}