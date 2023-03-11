namespace NovelCraft.Sdk;

internal struct Orientation: IOrientation {
  public decimal Yaw { get; set; }
  public decimal Pitch { get; set; }


  public Orientation(IOrientation orientation) {
    Yaw = orientation.Yaw;
    Pitch = orientation.Pitch;
  }

  public Orientation(decimal yaw, decimal pitch) {
    Yaw = yaw;
    Pitch = pitch;
  }
}