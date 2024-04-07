using MiniGameFramework.Items.Armor.Interfaces;

namespace MiniGameFramework.Items.Armor.Factory
{
    public class IronHelmet : ArmorBase, IHeadArmor
    {
        public override string Name { get { return "Iron Helmet"; } }

        public override int Defense { get { return 3; } }
    }

    public class IronChestplate : ArmorBase, IBodyArmor
    {
        public override string Name { get { return "Iron Chestplate"; } }

        public override int Defense { get { return 5; } }
    }

    public class IronLeggings : ArmorBase, ILegArmor
    {
        public override string Name { get { return "Iron Leggings"; } }

        public override int Defense { get { return 4; } }
    }
}
