using UnityEngine;

public class JumpTransition : Transition
{
   [SerializeField] private PlayerConfiguration _playerConfiguration;
   
   protected override void Enable()
   {
      base.Enable();
      _playerConfiguration.SurfaceCollisionDetector.InAir.AddListener(OnInAir);
      _playerConfiguration.InputListener.JumpKeyCodePress.AddListener(OnJumpKeyCodePressed);
   }

   protected override void Disable()
   {
      base.Enable();
      _playerConfiguration.SurfaceCollisionDetector.InAir.RemoveListener(OnInAir);
      _playerConfiguration.InputListener.JumpKeyCodePress.RemoveListener(OnJumpKeyCodePressed);
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
