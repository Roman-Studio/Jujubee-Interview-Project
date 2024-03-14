using System;
using Jujubee.Logic.Weapons.Types;
using UnityEngine;

namespace Jujubee.Logic.Weapons.Instances
{
    [Serializable]
    public class JBFirearmWeaponInstance : JBWeaponInstanceBase<JBFirearmWeapon>
    {
        [field: SerializeField]
        public int MagazinesLeft { get; private set; }
        
        [field: SerializeField]
        public int CurrentMagazinesBullets { get; private set; }

        public override void Initialize(JBFirearmWeapon weaponType)
        {
            base.Initialize(weaponType);

            if (WeaponType.StartingMagazines <= 0)
            {
                return;
            }
            
            MagazinesLeft = WeaponType.StartingMagazines - 1;
            CurrentMagazinesBullets = WeaponType.MagazineCapacity;
        }

        public override void UseWeapon()
        {
            if (CurrentMagazinesBullets > 0)
            {
                CurrentMagazinesBullets--;
                Debug.Log($"[{nameof(JBFirearmWeaponInstance)}.{nameof(UseWeapon)}] Shooting bullet from: {WeaponType.Name}!");
                return;
            }

            if (MagazinesLeft > 0)
            {
                MagazinesLeft--;
                CurrentMagazinesBullets = WeaponType.MagazineCapacity;
                Debug.Log($"[{nameof(JBFirearmWeaponInstance)}.{nameof(UseWeapon)}] Reloading: {WeaponType.Name}!");
                return;
            }
            
            Debug.Log($"[{nameof(JBFirearmWeaponInstance)}.{nameof(UseWeapon)}] No ammo left in: {WeaponType.Name}!");
        }
    }
}