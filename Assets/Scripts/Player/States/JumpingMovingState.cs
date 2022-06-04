using UnityEngine;

public class JumpingMovingState : MovingState
{
    [SerializeField,Range(0,100)] private float _jumpForce;
    [SerializeField,Range(0,100)] private int _countJump;
    [SerializeField,Range(0f,1f)] private float _jumpDirectionInterpolationCoefficient;
    [SerializeField, Range(0f, 100f)] private float _cooldownJump = .1f;
    
    private int _remainedJumpCount;
    private bool _canJump = true;

    protected override void OnEnter()
    {
        base.OnEnter();
        _playerConfiguration.InputListener.JumpKeyCodePress += OnJumpKeyCodePress;
    }

    protected override void OnExit()
    {
        base.OnExit();
        ResetJumpCount();
        _canJump = true;
        _playerConfiguration.InputListener.JumpKeyCodePress -= OnJumpKeyCodePress;

    }
    
    private void OnJumpKeyCodePress()
    {
        if (_canJump)
        {
            _canJump = false;
            Jump();
        }
    }

    private void Jump()
    {
        Vector3 jumpDirection =  _playerConfiguration.SurfaceCollisionDetector.GroundContactNormal;

        if (_playerConfiguration.SurfaceCollisionDetector.OnSteep && _playerConfiguration.SurfaceCollisionDetector.OnGround == false)
        {
            jumpDirection = _playerConfiguration.SurfaceCollisionDetector.SteepNormal;
            ResetJumpCount();
        }

        Debug.Log(_remainedJumpCount);
        
        if (_remainedJumpCount == 0) return;
        jumpDirection = Vector3.Lerp(jumpDirection, Vector3.up, _jumpDirectionInterpolationCoefficient).normalized;
        
        ResetVelocityY();
        
        _playerConfiguration.Rigidbody.AddForce(_jumpForce * jumpDirection, ForceMode.Impulse);
        
        _remainedJumpCount--;

        Invoke(nameof(AllowJumping), _cooldownJump);

    }

    private void ResetVelocityY()
    {
        var velocity = _playerConfiguration.Rigidbody.velocity;
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        
        _playerConfiguration.Rigidbody.velocity = velocity;
    }
    private void AllowJumping()
    {
        _canJump = true;
    }
    private void ResetJumpCount()
    {
        _remainedJumpCount = _countJump;
    }
    protected override Vector3 GetNormal()
    {
        return _playerConfiguration.SurfaceCollisionDetector.GroundContactNormal;
    }
    
}
