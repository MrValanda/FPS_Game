using UnityEngine;

public class GroundTransition : Transition
{
    [SerializeField] private PlayerConfiguration _playerConfiguration;

    protected override void Enable()
    {
        base.Enable();
        _playerConfiguration.SurfaceCollisionDetector.Landing.AddListener(OnLanding);
    }
    
    protected override void Disable()
    {
        base.Disable();
        _playerConfiguration.SurfaceCollisionDetector.Landing.RemoveListener(OnLanding);

    }

    private void OnLanding()
    {
        NeedTransit = true;
    }
    
}
