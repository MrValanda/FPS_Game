using UnityEngine;

public class GroundedMovingState : MovingState
{
    [SerializeField,Range(0,100)] private float _maxSnapSpeed;
    [SerializeField,Range(0,100)] private float _snapDistance;
    [SerializeField] private LayerMask _snapLayer;
    [SerializeField,Range(0,100)] private float _stepSinceLastGrounded=1f;
    [SerializeField,Range(0,100)] private float _stepsSinceLastJumpKeyPressed=10f;
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate(); 
        SnapToGround();
    }
  
    private void SnapToGround()
    {
        if (PlayerJumpOrGrounded())
            return;
        
        float speed = _playerConfiguration.Rigidbody.velocity.magnitude;
        
        if(speed> _maxSnapSpeed)
            return;
        
        if (!Physics.Raycast(transform.position, Vector3.down,out  RaycastHit hit, _snapDistance, _snapLayer))
        {
            return;
        }

        float dot = Vector3.Dot(_playerConfiguration.Rigidbody.velocity, hit.normal);
        if (dot > 0f) {
            _playerConfiguration.Rigidbody.velocity = Vector3.ProjectOnPlane(_playerConfiguration.Rigidbody.velocity,hit.normal).normalized * speed;
        }
        
    }

    private bool PlayerJumpOrGrounded()
    {
        return _playerConfiguration.SurfaceCollisionDetector.StepSinceLastGrounded > _stepSinceLastGrounded
               || _playerConfiguration.InputListener.StepsSinceLastJumpKeyPressed <_stepsSinceLastJumpKeyPressed;
    }

    protected override Vector3 GetNormal()
    {
        return _playerConfiguration.SurfaceCollisionDetector.GroundContactNormal;
    }
}
