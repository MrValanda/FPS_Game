using UnityEngine;

public class JumpTransition : Transition
{
   [SerializeField] private PlayerConfiguration _playerConfiguration;
   
   protected override void Enable()
   {
      base.Enable();
      _playerConfiguration.SurfaceCollisionDetector.InAir += OnInAir;
      _playerConfiguration.InputListener.JumpKeyCodePress += OnJumpKeyCodePressed;
   }

   protected override void Disable()
   {
      base.Enable();
      _playerConfiguration.SurfaceCollisionDetector.InAir -= OnInAir;
      _playerConfiguration.InputListener.JumpKeyCodePress -= OnJumpKeyCodePressed;
   }

   private void OnJumpKeyCodePressed()
   {
      NeedTransit = true;
   }

   private void OnInAir()
   {
      NeedTransit = true;
   }
}
