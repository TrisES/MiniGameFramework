namespace MiniGameFramework.Items.Weapons.Interfaces
{
    /// <summary>
    /// Represents a weapon. A weapon is also an item.
    /// </summary>
    /// <seealso cref="IItem" />
    public interface IWeapon : IItem
    {
        int Damage { get; set; }
    }
}
