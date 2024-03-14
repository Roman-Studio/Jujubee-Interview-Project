using System;
using Jujubee.Logic.Weapons.Types;
using UnityEngine;

namespace Jujubee.Logic.Weapons.Instances
{
    [Serializable]
    public class JBMeleeWeaponInstance : JBWeaponInstanceBase<JBMeleeWeapon>
    {
        public override void UseWeapon()
        {
            Debug.Log($"[{nameof(JBMeleeWeaponInstance)}.{nameof(UseWeapon)}] Using: {WeaponType.Name}!");
        }
    }
}