using MiniGameFramework.Items;

namespace MiniGameFramework.SupportClasses
{
    public abstract class Container
    {
        public List<IItem> Items { get; set; }

        public Container()
        {
            Items = new List<IItem>();
        }

        public IItem AddItem(IItem item)
        {
            Items.Add(item);

            return item;
        }

        public IItem? RemoveItem(IItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);

                return item;
            }

            return null;
        }
    }
}
