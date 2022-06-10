using UnityEngine;

public class InventoryManager : MonoBehaviour
{
   [SerializeField] private PlayerConfiguration _playerConfiguration;
   [SerializeField] private PlayerInventory _playerInventory;
   [SerializeField] private ItemRecognizer _itemRecognizer;
   [SerializeField,Range(0,100)] private int _forceDrop=10;


   private void OnEnable()
   {
      _playerConfiguration.InputListener.UseItemKeyCodePress.AddListener(OnUseItemKeyCodePress);
      _playerConfiguration.InputListener.TakeItemKeyCodePress.AddListener(OnTakeItemKeyCodePress);
      _playerConfiguration.InputListener.DropItemKeyCodePress.AddListener(OnDropItemKeyCodePress);
   }

   private void OnDisable()
   {
      _playerConfiguration.InputListener.UseItemKeyCodePress.RemoveListener(OnUseItemKeyCodePress);
      _playerConfiguration.InputListener.TakeItemKeyCodePress.RemoveListener(OnTakeItemKeyCodePress);
      _playerConfiguration.InputListener.DropItemKeyCodePress.RemoveListener(OnDropItemKeyCodePress);

   }

   private void OnTakeItemKeyCodePress()
   {
      _playerInventory.OnTakeItemKeyCodePress(_itemRecognizer.RecognitionItem());
   }

   private void OnUseItemKeyCodePress()
   {
      if (_playerInventory.TryGetCurrentItem(out Item currentItem))
      {
         Debug.Log(currentItem);
         currentItem.UseItem(_playerConfiguration.SpaceOrientation.forward);
      }
   }

   private void OnDropItemKeyCodePress()
   {
      if (_playerInventory.TryGetCurrentItem(out Item currentItem))
      {
         currentItem.DropItem(_playerConfiguration.SpaceOrientation.forward.normalized, _forceDrop);
         _playerInventory.DropCurrentItem();
      }
   }
   
}
