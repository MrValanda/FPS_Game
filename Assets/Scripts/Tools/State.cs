using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> _transitions;
    
    public void Enter()
    {
        if (enabled) return;
        
        enabled = true;
        foreach (var transition in _transitions)
        {
            transition.enabled = true;
        }
        OnEnter();
    }

    public void Exit()
    {
        if(enabled==false) return;
        enabled = false;
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }

        OnExit();
    }

    public State GetNextState()
    {
        return _transitions.FirstOrDefault(x => x.NeedTransit)?.NextState;
    }

    protected virtual void OnEnter(){}
    protected virtual void OnExit(){}

}
