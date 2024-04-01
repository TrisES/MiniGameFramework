namespace MiniGameFramework.Items
{
    public interface IWeapon : IItem, IEquipable
    {
        int Damage { get; set; }
    }
}
