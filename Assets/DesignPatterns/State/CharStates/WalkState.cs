public class WalkState : StateTemplate<Character>
{
    public WalkState(Character entity) : base(entity)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Entity.Animator.SetTrigger("walk");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        base.Tick();

        if(Entity.SpeedController.Speed >= Entity.RunSpeedCondition)
        {
            Entity.ChangeState(Entity.RunState);
        }
        else if(Entity.SpeedController.Speed == 0)
        {
            Entity.ChangeState(Entity.IdleState);
        }
    }

    public override void TickPhysics()
    {
        base.TickPhysics();
    }
}
