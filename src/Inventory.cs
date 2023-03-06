namespace NovelCraft.Sdk;

internal class Inventory : IInventory {
  public IItemStack? this[int index] {
    get {
      if (index < 0 || index >= Size) {
        throw new IndexOutOfRangeException();
      }

      return _itemStacks[index];
    }
    set {
      if (index < 0 || index >= Size) {
        throw new IndexOutOfRangeException();
      }

      _itemStacks[index] = (value is null ? null : new ItemStack(value.TypeId, value.Count));
    }
  }

  public int HotBarSize => 9;
  public int MainHandSlot { get; set; } = 0;
  public int Size => 36;

  private List<ItemStack?> _itemStacks = Enumerable.Repeat<ItemStack?>(null, 36).ToList();


  public Inventory() {
    // Empty
  }


  public void DropItem(int slot, int count) {
    if (slot < 0 || slot >= Size) {
      throw new IndexOutOfRangeException();
    }

    // TODO
  }

  public void MergeSlots(int fromSlot, int toSlot) {
    if (fromSlot < 0 || fromSlot >= Size) {
      throw new IndexOutOfRangeException();
    }

    if (toSlot < 0 || toSlot >= Size) {
      throw new IndexOutOfRangeException();
    }

    // TODO
  }

  public void SwapSlots(int slot1, int slot2) {
    if (slot1 < 0 || slot1 >= Size) {
      throw new IndexOutOfRangeException();
    }

    if (slot2 < 0 || slot2 >= Size) {
      throw new IndexOutOfRangeException();
    }

    // TODO
  }
}