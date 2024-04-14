using MiniGameFramework.Items;
using MiniGameFramework.Items.Armor.Interfaces;
using MiniGameFramework.Items.Weapons.Interfaces;

namespace MiniGameFramework.Creatures.Concrete
{
    /// <summary>
    /// Example implementation of a concrete creature class.
    /// Represents a human soldier. A human soldier is a creature.
    /// </summary>
    public class HumanSoldier : Creature
    {
        public IHeadArmor? HeadArmor { get; set; }
        public IBodyArmor? BodyArmor { get; set; }
        public ILegArmor? LegArmor { get; set; }
        public IMainHandWeapon? MainHandWeapon { get; set; }
        public IOffHandWeapon? OffHandWeapon { get; set; }

        public HumanSoldier(string name, int health, int baseDefense, int baseAttack) : base(name, health, baseDefense, baseAttack)
        {
        }

        /// <summary>
        /// Gets the sum of the defense values of the equipped armor.
        /// </summary>
        public override int ArmorDefenseSum 
        { 
            get
            {
                // Null-conditional operator (?.) is used to avoid null reference exceptions.
                return (HeadArmor?.Defense ?? 0) + (BodyArmor?.Defense ?? 0) + (LegArmor?.Defense ?? 0);
                // Kunne også bruge reflection til at finde alle properties der implementerer IArmor og derefter summe dem.
                // Det kunne gøres på base-klassen, så alle subklasser automatisk ville få det.
            }
        }

        /// <summary>
        /// Gets the sum of the attack values of the equipped weapons.
        /// </summary>
        public override int WeaponsAttackSum
        {
            get
            {
                return (MainHandWeapon?.Damage ?? 0) + (OffHandWeapon?.Damage ?? 0);
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        //public override bool Equip(IItem equipment)
        //{
        //    if (equipment is IHeadArmor headArmor)
        //    {
        //        HeadArmor = headArmor;
        //        return true;
        //    }
        //    else if (equipment is IBodyArmor bodyArmor)
        //    {
        //        BodyArmor = bodyArmor;
        //        return true;
        //    }
        //    else if (equipment is ILegArmor legArmor)
        //    {
        //        LegArmor = legArmor;
        //        return true;
        //    }
        //    else if (equipment is IMainHandWeapon mainHandWeapon)
        //    {
        //        MainHandWeapon = mainHandWeapon;
        //        return true;
        //    }
        //    else if (equipment is IOffHandWeapon offHandWeapon)
        //    {
        //        OffHandWeapon = offHandWeapon;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        /// <inheritdoc />
        public override bool Equip(IItem equipment)
        {
            switch (equipment)
            {
                case IHeadArmor headArmor when headArmor != null: // If the equipment is head armor and not null
                    if (HeadArmor != null) Inventory.Add(HeadArmor); // Add the currently equipped head armor to the inventory
                    HeadArmor = headArmor; // Equip the new head armor
                    Inventory.Delete(equipment.Id); // Remove the new head armor from the inventory
                    return true;
                case IBodyArmor bodyArmor when bodyArmor != null:
                    if (BodyArmor != null) Inventory.Add(BodyArmor);
                    BodyArmor = bodyArmor;
                    Inventory.Delete(equipment.Id);
                    return true;
                case ILegArmor legArmor when legArmor != null:
                    if (LegArmor != null) Inventory.Add(LegArmor);
                    LegArmor = legArmor;
                    Inventory.Delete(equipment.Id);
                    return true;
                case IMainHandWeapon mainHandWeapon when mainHandWeapon != null:
                    if (MainHandWeapon != null) Inventory.Add(MainHandWeapon);
                    MainHandWeapon = mainHandWeapon;
                    Inventory.Delete(equipment.Id);
                    return true;
                case IOffHandWeapon offHandWeapon when offHandWeapon != null:
                    if (OffHandWeapon != null) Inventory.Add(OffHandWeapon);
                    OffHandWeapon = offHandWeapon;
                    Inventory.Delete(equipment.Id);
                    return true;
                default:
                    return false;
            }
        }
    }
}
