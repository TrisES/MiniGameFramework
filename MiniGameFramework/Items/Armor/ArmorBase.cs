﻿using MiniGameFramework.Items.Armor.Interfaces;

namespace MiniGameFramework.Items.Armor
{
    public abstract class ArmorBase : IArmor
    {
        public abstract string Name { get; }
        public abstract int Defense { get; }

        public override string ToString()
        {
            return $"{Name} ({Defense} defense)";
        }
    }
}