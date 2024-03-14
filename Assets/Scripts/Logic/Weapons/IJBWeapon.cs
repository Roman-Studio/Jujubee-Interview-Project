using UnityEngine.AddressableAssets;

namespace Jujubee.Logic.Weapons
{
    public interface IJBWeapon
    {
        string Name { get; }
        AssetReferenceSprite Icon { get; }
        float Damage { get; }
        IJBWeaponInstance CreateInstance();
    }
}