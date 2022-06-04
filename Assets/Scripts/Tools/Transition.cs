using UnityEngine;

public class Transition : MonoBehaviour
{
   [field: SerializeField] public State NextState { get; private set; }

   public bool NeedTransit { get; protected set; }

   private void OnEnable()
   {
      NeedTransit = false;
      Enable();
   }

   private void OnDisable()
   {
      Disable();
   }

   protected virtual void Enable(){}
   protected virtual void Disable(){}
   
}
