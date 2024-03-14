using System.Collections;
using Jujubee.View.Core;
using Jujubee.View.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jujubee.View.Weapons
{
    public class JBWeaponsInventoryVisualization : JBObserverMonoBehaviour<JBPlayerWeaponsInventory>
    {
        [SerializeField]
        private JBPlayerWeaponsInventory _WeaponsInventory;

        [SerializeField]
        private TextMeshProUGUI _WeaponName;

        [SerializeField]
        private Image _WeaponIcon;

        private IEnumerator Start()
        {
            yield return null;
            Set(_WeaponsInventory);
        }
        
        protected override void RegisterEvents()
        {
            ObservedObject.EventNextWeaponSelected += ReactToChanges;
        }

        protected override void UnregisterEvents()
        {
            ObservedObject.EventNextWeaponSelected -= ReactToChanges;
        }

        protected override void OnReactToChanges()
        {
            var weaponType = _WeaponsInventory.SelectedWeaponInstance.GetWeaponType();
            _WeaponName.text = weaponType.Name;
            _WeaponIcon.sprite = weaponType.Icon;
        }
    }
}