namespace NovelCraft.Sdk;

internal struct Orientation: IOrientation {
  public decimal Yaw { get; set; }
  public decimal Pitch { get; set; }


  public Orientation(decimal yaw, decimal pitch) {
    Yaw = yaw;
    Pitch = pitch;
  }
}