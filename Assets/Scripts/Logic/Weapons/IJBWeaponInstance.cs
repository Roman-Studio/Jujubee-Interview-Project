namespace Jujubee.Logic.Weapons
{
    public interface IJBWeaponInstance
    {
        IJBWeapon GetWeaponType();
        void UseWeapon();
    }
}