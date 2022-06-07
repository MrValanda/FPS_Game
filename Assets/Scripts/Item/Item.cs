using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [field: SerializeField] public ItemProperty ItemProperty { get; private set; }

    public abstract void UseItem(Vector3 direction);
    public abstract void SelectItem();
    public abstract void DropItem();
   
}
