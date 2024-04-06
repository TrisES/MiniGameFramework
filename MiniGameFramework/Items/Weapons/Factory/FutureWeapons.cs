namespace MiniGameFramework.Items.Weapons.Factory
{
    public class LaserAxe : WeaponBase
    {
        public override string Name { get { return "Laser Axe"; } }

        public override int Damage { get { return 30; } }
    }

    public class LaserSword : WeaponBase
    {
        public override string Name { get { return "Laser Sword"; } }

        public override int Damage { get { return 25; } }
    }

    public class LaserDagger : WeaponBase
    {
        public override string Name { get { return "Laser Dagger"; } }

        public override int Damage { get { return 20; } }
    }

}
