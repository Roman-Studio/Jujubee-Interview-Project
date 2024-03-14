using Jujubee.Logic.Weapons.Instances;
using UnityEngine;

namespace Jujubee.Logic.Weapons.Types
{
    [CreateAssetMenu(fileName = "FirearmWeapon", menuName = "Jujubee/Weapons/FirearmWeapon")]
    public class JBFirearmWeapon : JBWeaponBase
    {
        [field: SerializeField] 
        public int MagazineCapacity { get; private set; } = 5;

        [field: SerializeField] 
        public int StartingMagazines { get; private set; } = 2;

        public override IJBWeaponInstance CreateInstance()
        {
            var newWeaponInstance = new JBFirearmWeaponInstance();
            newWeaponInstance.Initialize(this);
            return newWeaponInstance;
        }
    }
}