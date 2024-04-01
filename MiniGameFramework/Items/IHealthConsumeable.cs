namespace MiniGameFramework.Items
{
    public interface IHealthConsumeable : IItem, IConsumeable
    {
        public int HealingAmount { get; set; }
    }
}
