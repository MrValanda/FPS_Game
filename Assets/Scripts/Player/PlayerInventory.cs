using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;
    [SerializeField] private Transform _parentForWeapon;
    [SerializeField] private ItemRecognizer _itemRecognizer;
    [SerializeField,Range(0,100f)] private int _inventorySize = 4;
    
    private List<Item> _inventory;
    private Item _currentItem;

    private void OnEnable()
    {
        _inputListener.TakeItemKeyCodePress.AddListener(OnTakeItemKeyCodePress);
    }

    private void OnDisable()
    {
        _inputListener.TakeItemKeyCodePress.RemoveListener(OnTakeItemKeyCodePress);
    }

    private void Start()
    {
        _inventory = new List<Item>();
   }

    private void TakeItem(Item newItem)
    {
        if (_inventory.Count < _inventorySize)
        {
            _inventory.Add(newItem);

            Destroy(newItem.gameObject);

        }
        Debug.Log("Take " + _inventory.Count);
    }

    private void DropCurrentItem(Vector3 dropDirection)
    {
        
    }

    private void SelectItemByIndex(int index)
    {
        index = Mathf.Clamp(index, 0, _inventory.Count - 1);
        if (_currentItem != null)
            Destroy(_currentItem.gameObject);
        _currentItem = Instantiate(_inventory[index], _parentForWeapon);
        _currentItem.transform.localPosition=Vector3.zero;
        _currentItem.SelectItem();
    }

   public bool TryGetCurrentItem(out Item currentItem)
   {
       currentItem = _currentItem;
      return currentItem!=null;
   }

   private void OnTakeItemKeyCodePress()
   {
       var recognitionItem = _itemRecognizer.RecognitionItem();
       if(recognitionItem==null) return;
       TakeItem(recognitionItem);
       SelectItemByIndex(_inventory.Count);
   }
   
}
