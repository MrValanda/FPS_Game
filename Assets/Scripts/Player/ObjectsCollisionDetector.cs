using UnityEngine;
using UnityEngine.Events;

public class ObjectsCollisionDetector : MonoBehaviour
{
    public UnityEvent<Item> ItemCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            ItemCollision?.Invoke(item);

        }
        Debug.Log(other.name);

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
    }
}
