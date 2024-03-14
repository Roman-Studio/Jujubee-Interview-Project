using UnityEngine;

namespace Jujubee.Logic.Player
{
    public class JBPlayerController : MonoBehaviour
    {
        [SerializeField]
        private JBPlayerWeaponsInventory _WeaponsInventory;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _WeaponsInventory.SelectedWeaponInstance.UseWeapon();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _WeaponsInventory.SelectNextWeapon();
            }
        }
    }
}