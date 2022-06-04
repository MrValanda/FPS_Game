using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private Transform _parentForWeapon;

   private void Start()
   {
       _currentWeapon = Instantiate(_currentWeapon, _parentForWeapon);
   }

   public bool TryGetCurrentWeapon(out Weapon currentWeapon)
   {
      currentWeapon = _currentWeapon;
      return currentWeapon!=null;
   }
   
}
