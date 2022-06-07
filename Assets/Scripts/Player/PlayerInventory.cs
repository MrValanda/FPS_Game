using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;
    [SerializeField] private Transform _parentForWeapon;
    [SerializeField] private ItemRecognizer _itemRecognizer;
    [SerializeField,Range(0,100f)] private int _inventorySize = 4;
    
    private List<Item> _inventory;
    private int _currentItemIndex = -1;

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
            newItem.gameObject.SetActive(false);
        }
    }

    public void DropCurrentItem()
    {
        _inventory.RemoveAt(_currentItemIndex);
        _currentItemIndex = -1;
        if (_inventory.Count > 0)
            SelectItemByIndex(Random.Range(0, _inventory.Count));
    }

    private void SelectItemByIndex(int index)
    {
        index = Mathf.Clamp(index, 0, _inventory.Count - 1);
        if (_currentItemIndex != -1)
        {
            _inventory[_currentItemIndex].gameObject.SetActive(false);
        }
        
        _inventory[index].gameObject.SetActive(true);
        _inventory[index].transform.position = _parentForWeapon.position;
        _inventory[index].transform.rotation = _parentForWeapon.rotation;
        _inventory[index].transform.SetParent(_parentForWeapon);
        _inventory[index].SelectItem();
        
        _currentItemIndex = index;
    }

   public bool TryGetCurrentItem(out Item currentItem)
   {
       Debug.Log(_currentItemIndex);
       if (_currentItemIndex == -1)
       {
           currentItem = null;
           return false;
       }
       
       currentItem = _inventory[_currentItemIndex];
       return true;
   }

   private void OnTakeItemKeyCodePress()
   {
       var recognitionItem = _itemRecognizer.RecognitionItem();
       if(recognitionItem==null) return;
       TakeItem(recognitionItem);
       SelectItemByIndex(_inventory.Count);
   }
   
}
