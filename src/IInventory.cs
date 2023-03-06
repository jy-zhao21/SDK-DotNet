namespace NovelCraft.Sdk;

public interface IInventory {
  /// <summary>
  /// Gets the item in the specified slot.
  /// </summary>
  /// <param name="index">The slot to get the item from.</param>
  /// <returns>The item in the specified slot.</returns>
  public IItemStack this[int index] { get; }

  /// <summary>
  /// Gets the number of slots in the hot bar.
  /// </summary>
  public int HotBarSize { get; }

  /// <summary>
  /// Gets or sets the slot that the main hand is currently in.
  /// </summary>
  /// <remarks>
  /// The value of this property must be in the range [0, HotBarSize).
  /// </remarks>
  public int MainHandSlot { get; set; }

  /// <summary>
  /// Gets the number of slots in the inventory.
  /// </summary>
  public int Size { get; }

  /// <summary>
  /// Drops items from a slot into the world.
  /// </summary>
  /// <param name="slot">The slot to drop items from.</param>
  /// <param name="count">The number of items to drop.</param>
  public void DropItem(int slot, int count);

  /// <summary>
  /// Swaps the contents of two slots.
  /// </summary>
  public void SwapSlots(int slot1, int slot2);

  /// <summary>
  /// Merges items from two slots into one slot.
  /// </summary>
  /// <param name="fromSlot">The slot to take items from.</param>
  /// <param name="toSlot">The slot to put items into.</param>
  /// <remarks>
  /// If the items in the two slots are not the same type, nothing happens.
  /// If the number of items in the two slots is greater than the maximum stack size,
  /// toSlot will be filled to the maximum stack size and the remaining items will be
  /// left in fromSlot.
  /// </remarks>
  public void MergeSlots(int fromSlot, int toSlot);
}