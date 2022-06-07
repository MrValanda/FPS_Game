using UnityEngine;

public class ItemUseController : MonoBehaviour
{
   [SerializeField] private PlayerConfiguration _playerConfiguration;
   [SerializeField] private PlayerInventory _playerInventory;

   private void OnEnable()
   {
      _playerConfiguration.InputListener.UseItemKeyCodePress.AddListener(OnUseItemKeyCodePress);
   }

   private void OnDisable()
   {
      _playerConfiguration.InputListener.UseItemKeyCodePress.RemoveListener(OnUseItemKeyCodePress);
   }

   private void OnUseItemKeyCodePress()
   {
      if (_playerInventory.TryGetCurrentItem(out Item currentItem))
      {
         Debug.Log(currentItem.name);
         currentItem.UseItem(_playerConfiguration.SpaceOrientation.forward);
      }
   }
   
}
