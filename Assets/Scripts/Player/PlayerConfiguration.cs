using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SurfaceCollisionDetector))]
public class PlayerConfiguration : MonoBehaviour
{
    [field: SerializeField] public Transform SpaceOrientation { get; private set; }

    [field: SerializeField] public InputListener InputListener { get; private set; }
    public SurfaceCollisionDetector SurfaceCollisionDetector { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        SurfaceCollisionDetector = GetComponent<SurfaceCollisionDetector>();
    }
}
