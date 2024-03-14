using System;
using UnityEngine;

namespace Jujubee.Logic.Weapons
{
    [Serializable]
    public abstract class JBWeaponInstanceBase<TWeaponType> : IJBWeaponInstance
        where TWeaponType : IJBWeapon
    {
        [field: SerializeField]
        public TWeaponType WeaponType { get; private set; }

        public virtual void Initialize(TWeaponType weaponType) 
        {
            WeaponType = weaponType;
        }

        public abstract void UseWeapon();
    }
}