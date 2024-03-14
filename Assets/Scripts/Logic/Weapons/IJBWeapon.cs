using UnityEngine;

namespace Jujubee.Logic.Weapons
{
    public interface IJBWeapon
    {
        string Name { get; }
        Sprite Icon { get; }
        IJBWeaponInstance CreateInstance();
    }
}