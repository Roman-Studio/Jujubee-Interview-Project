using Jujubee.Logic.Weapons.Instances;
using UnityEngine;

namespace Jujubee.Logic.Weapons.Types
{
    [CreateAssetMenu(fileName = "MeleeWeapon", menuName = "Jujubee/Weapons/MeleeWeapon")]
    public class JBMeleeWeapon : JBWeaponBase
    {
        [field: SerializeField] 
        public float StaminaCost { get; private set; } = 10f;

        public override IJBWeaponInstance CreateInstance()
        {
            var newWeaponInstance = new JBMeleeWeaponInstance();
            newWeaponInstance.Initialize(this);
            return newWeaponInstance;
        }
    }
}