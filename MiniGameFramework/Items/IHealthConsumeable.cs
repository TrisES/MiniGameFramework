namespace MiniGameFramework.Items
{
    public interface IHealthConsumeable : IItem
    {
        public int HealingAmount { get; set; }
    }
}
