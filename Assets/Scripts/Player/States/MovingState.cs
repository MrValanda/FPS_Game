using UnityEngine;

public abstract class MovingState : State
{
    [SerializeField] protected PlayerConfiguration _playerConfiguration;
    [SerializeField,Range(0,100)] protected float _maxSpeed;
    [SerializeField, Range(0, 100)] protected float _maxAcceleration;
    [SerializeField, Range(0, 1f)] protected float _coefficientFriction;

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        Vector3 velocity = _playerConfiguration.Rigidbody.velocity;
        Vector3 moveDirection = GetMoveDirection();
        velocity.y = 0;
        
        Vector3 friction = -velocity * _coefficientFriction;
        
        float currentSpeed = Vector3.Dot(velocity, moveDirection);
        float addSpeed = Mathf.Clamp(_maxSpeed - currentSpeed,0f,_maxAcceleration);
        
        _playerConfiguration.Rigidbody.AddForce(GetMoveDirection() * addSpeed + friction, ForceMode.VelocityChange);
    }
    protected virtual Vector3 GetMoveDirection()
    {
        Vector3 right = _playerConfiguration.SpaceOrientation.right;
        Vector3 forward = _playerConfiguration.SpaceOrientation.forward;
        right.y = forward.y = 0;
        right = right.normalized;
        forward = forward.normalized;
        Vector3 moveDirection =
            Vector3.ProjectOnPlane(
                forward * _playerConfiguration.InputListener.PlayerInput.y +
                right * _playerConfiguration.InputListener.PlayerInput.x,
                GetNormal());

        return moveDirection;
    }

    protected abstract Vector3 GetNormal();
}
