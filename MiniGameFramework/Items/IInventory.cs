namespace MiniGameFramework.Items
{
    /// <summary>
    /// Represents an inventory that can hold items.
    /// </summary>
    public interface IInventory
    {
        // Design Considerations:
        // - What properties should this interface have? (e.g. Capacity, Items)
        // - What methods should this interface have? (e.g. AddItem, RemoveItem, GetItem)

        // Bonus: This interface could be generic to allow for different types of items to be stored in the inventory.
        // Bonus: This interface could inherit from IEnumerable<IItem> to allow for the inventory to be enumerated.
        // Bonus: This interface could have an event that is raised when an item is added or removed from the inventory.
        // Bonus: This interface could have a method to sort the items in the inventory.
        // Bonus: This interface could have a method to filter the items in the inventory.
        // Bonus: This interface could have a method to find an item in the inventory.
        // Conclusion: this is basically a repository pattern, but for items.

        // TODO: Implement this interface.
    }
}