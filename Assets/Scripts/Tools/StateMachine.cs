using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] protected State _startState;

    protected State CurrentState { get; set; }

    protected void Start()
    {
        ResetState(_startState);
    }

    protected virtual void ResetState(State startState)
    {
        CurrentState = startState;
        if (CurrentState != null)
        {
            CurrentState.Enter();
        }
    }

    protected virtual void Update()
    {
        if(CurrentState==null)
            return;

        State nextState = CurrentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    protected virtual void Transit(State nextState)
    {
        if (CurrentState != null)
            CurrentState.Exit();
        
        CurrentState = nextState;
        
        if (CurrentState != null)
            CurrentState.Enter();
    }
}
