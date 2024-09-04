public class RunState : StateTemplate<Character>
{
    public RunState(Character entity) : base(entity)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Entity.Animator.SetTrigger("run");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        base.Tick();

        if (Entity.SpeedController.Speed < 1.5f)
        {
            Entity.ChangeState(Entity.WalkState);
        }
    }

    public override void TickPhysics()
    {
        base.TickPhysics();
    }
}
