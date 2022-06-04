using UnityEngine;
using UnityEngine.Events;

public class SurfaceCollisionDetector : MonoBehaviour
{
    [SerializeField] private AnglesCollisions _anglesCollisions;

    public UnityAction Landing;
    public UnityAction InAir;
    public Vector3 GroundContactNormal { get; private set; }
    public Vector3 SteepNormal { get; private set; }

    public bool OnGround { get; private set; }
    public bool OnSteep  { get; private set; }

    public int StepSinceLastGrounded { get; private set; }



    private void FixedUpdate()
    {
        StepSinceLastGrounded++;

        if (OnGround)
        {
            StepSinceLastGrounded = 0;
        }
        else
        {
            InAir?.Invoke();
            GroundContactNormal=Vector3.up;
        }

        OnSteep = OnGround = false;
        SteepNormal = Vector3.zero;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
    }

    private void EvaluateCollision(Collision collision)
    {
        foreach (var collisionContact in collision.contacts)
        {
            if (collisionContact.normal.y > _anglesCollisions.MinGroundDotProduct)
            {
                GroundContactNormal += collisionContact.normal;
                OnGround = true;
                Landing?.Invoke();
            }
            else
            {
                SteepNormal += collisionContact.normal;
                OnSteep = true;
            }
        }
        
        SteepNormal = SteepNormal.normalized;
        GroundContactNormal = GroundContactNormal.normalized;

    }
}
