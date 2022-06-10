using UnityEngine;
using UnityEngine.Events;

public class ObjectsCollisionDetector : MonoBehaviour
{
    public UnityEvent<GameObject> ObjectCollision;
    
    private void OnCollisionEnter(Collision other)
    {
        ObjectCollision?.Invoke(other.gameObject);
    }
}
