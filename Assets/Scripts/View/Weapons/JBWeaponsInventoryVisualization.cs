using System.Collections;
using Jujubee.Logic.Weapons;
using Jujubee.View.Core;
using Jujubee.View.Player;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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
        
        private AsyncOperationHandle<Sprite> _LoadIconOperationHandle;

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
            StartCoroutine(LoadItemIcon(weaponType));
        }

        private IEnumerator LoadItemIcon(IJBWeapon weaponType)
        {
            yield return UnloadPreviousIcon();
            _LoadIconOperationHandle = Addressables.LoadAssetAsync<Sprite>(weaponType.IconAssetReference);
            _LoadIconOperationHandle.Completed += SetWeaponIconAfterLoad;
        }

        private void SetWeaponIconAfterLoad(AsyncOperationHandle<Sprite> operationHandle)
        {
            _WeaponIcon.sprite = operationHandle.Result;
        }

        private IEnumerator UnloadPreviousIcon()
        {
            if (!_LoadIconOperationHandle.IsValid())
            {
                yield break;
            }
            
            if (!_LoadIconOperationHandle.IsDone)
            {
                yield return new WaitUntil(() => _LoadIconOperationHandle.IsDone);
            }
            
            Addressables.Release(_LoadIconOperationHandle);
        }
    }
}