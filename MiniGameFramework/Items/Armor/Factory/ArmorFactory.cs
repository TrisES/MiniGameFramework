using MiniGameFramework.Items.Armor.Interfaces;
using MiniGameFramework.Logging;
using System.Diagnostics;

namespace MiniGameFramework.Items.Armor.Factory
{
    public class ArmorFactory : IArmorFactoryMethod
    {
        public IArmor CreateArmor(string armor)
        {
            GameLogger.Log($"{this.GetType().Name} - trying to create armor: \"{armor}\"", TraceEventType.Information);

            IArmor armorObject = null;
            switch (armor)
            {
                case "Iron Helmet":
                    armorObject = new IronHelmet();
                    break;
                case "Iron Chestplate":
                    armorObject = new IronChestplate();
                    break;
                case "Iron Leggings":
                    armorObject = new IronLeggings();
                    break;
                case "Future Helmet":
                    armorObject = new FutureHelmet();
                    break;
                case "Future Chestplate":
                    armorObject = new FutureChestplate();
                    break;
                case "Future Leggings":
                    armorObject = new FutureLeggings();
                    break;
                default:
                    string message = $"{this.GetType().Name} - no class found for weapon: \"{armor}\"";
                    GameLogger.Log(message, TraceEventType.Error);
                    throw new ArgumentException(message);
            }

            GameLogger.Log($"{this.GetType().Name} - created armor: \"{armorObject.Name}\"", TraceEventType.Information);
            return armorObject;
        }
    }
}
