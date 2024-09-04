using UnityEngine;

public class StatefulBehaviour : MonoBehaviour
{
    public StateMachine<IState> StateMachine = new();
    private bool enable = false;

    public void InitMachine(IState state)
    {
        StateMachine.StartWithState(state);
        enable = true;
    }

    protected virtual void Update()
    {
        if(enable)
            StateMachine.CurrentState.Tick();
    }

    protected virtual void FixedUpdate()
    {
        if(enable)
            StateMachine.CurrentState.TickPhysics();
    }
}