using MiniGameFramework.Items.Armor.Interfaces;

namespace MiniGameFramework.Items.Armor.Factory
{
    public class FutureHelmet : ArmorBase, IHeadArmor
    {
        public override string Name { get { return "Future Helmet"; } }

        public override int Defense { get { return 5; } }
    }

    public class FutureChestplate : ArmorBase, IBodyArmor
    {
        public override string Name { get { return "Future Chestplate"; } }

        public override int Defense { get { return 8; } }
    }

    public class FutureLeggings : ArmorBase, ILegArmor
    {
        public override string Name { get { return "Future Leggings"; } }

        public override int Defense { get { return 6; } }
    }
}
