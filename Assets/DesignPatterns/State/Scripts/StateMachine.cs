using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine<T> where T : IState
{
    public T CurrentState { get; private set; }
    public T PreviousState { get; private set; }

    public List<string> StateLog = new List<string>();

    public StateMachine()
    {

    }

    public StateMachine(T state)
    {
        CurrentState = state;
        state.OnStateEnter();
        KeepLog(state);
    }

    public void StartWithState(T state)
    {
        CurrentState = state;
        state.OnStateEnter();
        KeepLog(state);
    }

    public void ChangeState(T newState)
    {
        CurrentState.OnStateExit();
        PreviousState = CurrentState;
        CurrentState = newState;
        newState.OnStateEnter();
        KeepLog(newState);
    }

    public T GetPreviousState()
    {
        return PreviousState;
    }

    public void KeepLog(T state)
    {
        StateLog.Add(state.ToString() + " " + Time.time.ToString());
    }

}
