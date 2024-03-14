using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Jujubee.Logic.Weapons
{
    public abstract class JBWeaponBase : ScriptableObject, IJBWeapon
    {
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public AssetReferenceSprite Icon { get; private set; }
        
        [field: SerializeField]
        public float Damage { get; private set; }

        public abstract IJBWeaponInstance CreateInstance();
    }
}