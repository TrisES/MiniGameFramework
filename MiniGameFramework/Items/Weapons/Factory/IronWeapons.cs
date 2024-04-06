namespace MiniGameFramework.Items.Weapons.Factory
{
    public class IronAxe : WeaponBase
    {
        public override string Name { get { return "Iron Axe"; } }
        public override int Damage { get { return 15; } }
    }

    public class IronSword : WeaponBase
    {
        public override string Name { get { return "Iron Sword"; } }
        public override int Damage { get { return 10; } }
    }

    public class IronDagger : WeaponBase
    {
        public override string Name { get { return "Iron Dagger"; } }
        public override int Damage { get { return 5; } }
    }
}