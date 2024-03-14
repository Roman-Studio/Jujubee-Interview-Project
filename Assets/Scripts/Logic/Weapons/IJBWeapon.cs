using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Jujubee.Logic.Weapons
{
    public interface IJBWeapon
    {
        string Name { get; }
        AssetReferenceSprite IconAssetReference { get; }
        IJBWeaponInstance CreateInstance();
    }
}