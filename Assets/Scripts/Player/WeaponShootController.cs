using System;
using UnityEngine;

public class WeaponShootController : MonoBehaviour
{
   [SerializeField] private PlayerConfiguration _playerConfiguration;
   [SerializeField] private PlayerInventory _playerInventory;

   private float _timeAfterLastShoot;
   private void OnEnable()
   {
      _playerConfiguration.InputListener.ShootKeyCodePress += OnShootKeyCodePressed;
   }

   private void OnDisable()
   {
      _playerConfiguration.InputListener.ShootKeyCodePress -= OnShootKeyCodePressed;
   }

   private void Update()
   {
      _timeAfterLastShoot += Time.deltaTime;
   }

   private void OnShootKeyCodePressed()
   {
      if (_playerInventory.TryGetCurrentWeapon(out Weapon currentWeapon))
      {
         if (_timeAfterLastShoot > currentWeapon.RateFire)
         {
            _timeAfterLastShoot =0;
            currentWeapon.Shoot(_playerConfiguration.SpaceOrientation.forward);
         }
      }
   }
}
