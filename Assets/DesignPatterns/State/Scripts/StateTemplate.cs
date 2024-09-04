using UnityEngine;

public abstract class StateTemplate<T> : IState
{
    protected T Entity;

    private float OnStateEnterTime;
    private float OnStateExitTime;

    private int TickCount = 0;
    private int TransitionIntoCount = 0;

    public StateTemplate(T entity)
    {
        this.Entity = entity; 
    }

    public float GetElapsedTimeOnState()
    {
        return Time.time - OnStateEnterTime;
    }

    public float GetOnStateEnterTime()
    {
        return OnStateEnterTime;
    }

    public float GetOnStateExitTime()
    {
        return OnStateExitTime;
    }

    public int GetTickCount() => TickCount;

    public virtual void OnStateEnter()
    {
        TickCount = 0;
        TransitionIntoCount++;
        OnStateEnterTime = Time.time;
    }

    public virtual void OnStateExit()
    {
        OnStateExitTime = Time.time;
    }

    public virtual void Tick()
    {
        TickCount++;
    }

    public virtual void TickPhysics()
    {

    }
}
