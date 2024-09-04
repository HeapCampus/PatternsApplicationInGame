public interface IState
{
    void OnStateEnter();
    void OnStateExit();
    void Tick();
    void TickPhysics();
    float GetOnStateEnterTime();
    float GetOnStateExitTime();
    float GetElapsedTimeOnState();
}
