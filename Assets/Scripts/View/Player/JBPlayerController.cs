using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Jujubee.View.Player
{
    public class JBPlayerController : MonoBehaviour
    {
        [SerializeField, Foldout("References")]
        private JBPlayerWeaponsInventory _WeaponsInventory;

        [SerializeField, Foldout("Input")]
        private InputActionReference _UseWeaponActionReference;
        
        [SerializeField, Foldout("Input")]
        private InputActionReference _NextWeaponActionReference;

        private void Start()
        {
            RegisterInputs();
        }

        private void OnDestroy()
        {
            UnregisterInputs();
        }

        private void OnEnable()
        {
            EnableInputActions();
        }

        private void OnDisable()
        {
            DisableInputActions();
        }

        private void EnableInputActions()
        {
            _UseWeaponActionReference.action.Enable();
            _NextWeaponActionReference.action.Enable();
        }

        private void DisableInputActions()
        {
            _UseWeaponActionReference.action.Disable();
            _NextWeaponActionReference.action.Disable();
        }

        private void RegisterInputs()
        {
            _UseWeaponActionReference.action.performed += UseWeapon;
            _NextWeaponActionReference.action.performed += SelectNextWeapon;
        }
        
        private void UnregisterInputs()
        {
            _UseWeaponActionReference.action.performed -= UseWeapon;
            _NextWeaponActionReference.action.performed -= SelectNextWeapon;
        }

        private void UseWeapon(InputAction.CallbackContext callbackContext)
        {
            _WeaponsInventory.SelectedWeaponInstance.UseWeapon();
        }

        private void SelectNextWeapon(InputAction.CallbackContext callbackContext)
        {
            _WeaponsInventory.SelectNextWeapon();
        }
    }
}