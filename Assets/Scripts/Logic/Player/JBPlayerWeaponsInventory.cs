using System;
using System.Collections.Generic;
using Jujubee.Logic.Weapons;
using NaughtyAttributes;
using UnityEngine;

namespace Jujubee.Logic.Player
{
    public class JBPlayerWeaponsInventory : MonoBehaviour
    {
        [SerializeField]
        private List<JBWeaponBase> _StartingWeapons;//Normally if I could use Odin it would be List<IJBWeapon>

        [SerializeField, SerializeReference, ReadOnly]
        private List<IJBWeaponInstance> _AvailableWeapons;
        public IReadOnlyList<IJBWeaponInstance> AvailableWeapons => _AvailableWeapons;

        [ShowNonSerializedField]
        private int SelectedWeaponIndex;
        public IJBWeaponInstance SelectedWeaponInstance => AvailableWeapons[SelectedWeaponIndex];
        public event Action EventNextWeaponSelected;

        private void Start()
        {
            GetStartingWeaponsInstances();
        }

        private void GetStartingWeaponsInstances()
        {
            foreach (var weapon in _StartingWeapons)
            {
                _AvailableWeapons.Add(weapon.CreateInstance());
            }
        }

        public void SelectNextWeapon()
        {
            SelectedWeaponIndex++;

            if (SelectedWeaponIndex >= AvailableWeapons.Count)
            {
                SelectedWeaponIndex = 0;
            }
            
            EventNextWeaponSelected?.Invoke();
        }
    }
}