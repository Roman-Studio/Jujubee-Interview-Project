using UnityEngine;

namespace Jujubee.Logic.Weapons
{
    public abstract class JBWeaponBase : ScriptableObject, IJBWeapon
    {
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public Sprite Icon { get; private set; }
        
        [field: SerializeField]
        public float Damage { get; private set; }

        public abstract IJBWeaponInstance CreateInstance();
    }
}