namespace MiniGameFramework.Items.Weapons.Factory
{
    public class DiamondAxe : WeaponBase
    {
        public override string Name { get { return "Diamond Axe"; } }

        public override int Damage { get { return 25; } }
    }

    public class DiamondSword : WeaponBase
    {
        public override string Name { get { return "Diamond Sword"; } }

        public override int Damage { get { return 20; } }
    }

    public class DiamondDagger : WeaponBase
    {
        public override string Name { get { return "Diamond Dagger"; } }

        public override int Damage { get { return 15; } }
    }
}
