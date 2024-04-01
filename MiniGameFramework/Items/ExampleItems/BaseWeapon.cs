using MiniGameFramework.Creatures;

namespace MiniGameFramework.Items.ExampleItems
{
    public class BaseWeapon : IWeapon
    {
        public int Damage { get; set; }
        public string Name { get; set; }

        public BaseWeapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void Equip(Creature user)
        {
            throw new NotImplementedException();
        }

        public void Unequip(Creature user)
        {
            throw new NotImplementedException();
        }

        public void Use(Creature user)
        {
            throw new NotImplementedException();
        }
    }
}
