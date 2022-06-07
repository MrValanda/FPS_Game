using System;
using UnityEngine;

public class JumpingMovingState : MovingState
{
    [SerializeField,Range(0,100)] private float _jumpForce;
    [SerializeField,Range(0,100)] private int _countJump;
    [SerializeField,Range(0f,1f)] private float _jumpDirectionInterpolationCoefficient;
    [SerializeField, Range(0f, 100f)] private float _cooldownJump = .1f;
    
    private int _remainedJumpCount;
    private bool _canJump => _timeAfterJump >= _cooldownJump;

    private float _timeAfterJump;
    protected override void OnEnter()
    {
        base.OnEnter();
        _playerConfiguration.InputListener.JumpKeyCodePress.AddListener(OnJumpKeyCodePress);
    }

    protected override void OnExit()
    {
        base.OnExit();
        ResetJumpCount();
        _timeAfterJump = _cooldownJump;
        _playerConfiguration.InputListener.JumpKeyCodePress.RemoveListener(OnJumpKeyCodePress);

    }
    private void Update()
    {
        _timeAfterJump += Time.deltaTime;
    }

    private void OnJumpKeyCodePress()
    {
        if (_canJump)
        {
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
        _timeAfterJump = 0;

        jumpDirection = Vector3.Lerp(jumpDirection, Vector3.up, _jumpDirectionInterpolationCoefficient).normalized;
        
        ResetYVelocity();
        
        _playerConfiguration.Rigidbody.AddForce(_jumpForce * jumpDirection, ForceMode.Impulse);
        
        _remainedJumpCount--;


    }

    private void ResetYVelocity()
    {
        var velocity = _playerConfiguration.Rigidbody.velocity;
        velocity = new Vector3(velocity.x, 0f, velocity.z);
        
        _playerConfiguration.Rigidbody.velocity = velocity;
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
