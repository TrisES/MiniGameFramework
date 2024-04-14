using MiniGameFramework.Items.Weapons.Interfaces;

namespace MiniGameFramework.Items.Weapons.Factory
{
    public class IronAxe : WeaponBase, IMainHandWeapon
    {
        public override string Name { get { return "Iron Axe"; } }
        public override int Damage { get { return 15; } }
    }

    public class IronSword : WeaponBase, IMainHandWeapon
    {
        public override string Name { get { return "Iron Sword"; } }
        public override int Damage { get { return 10; } }
    }

    public class IronDagger : WeaponBase, IOffHandWeapon
    {
        public override string Name { get { return "Iron Dagger"; } }
        public override int Damage { get { return 5; } }
    }
}