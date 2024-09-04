public class JumpState : StateTemplate<Character>
{
    private float animTime;
    public JumpState(Character entity) : base(entity)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Entity.Animator.SetTrigger("jump");
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        base.Tick();
        
        if(GetTickCount() == 1)
        {
            animTime = Entity.Animator.GetNextAnimatorClipInfo(0)[0].clip.length;
        }

        if (GetElapsedTimeOnState() > 0.867f)
        {
            if (Entity.SpeedController.Speed == 0)
                Entity.ChangeState(Entity.IdleState);
            else if (Entity.SpeedController.Speed < Entity.RunSpeedCondition)
                Entity.ChangeState(Entity.WalkState);
            else if (Entity.SpeedController.Speed >= Entity.RunSpeedCondition)
                Entity.ChangeState(Entity.RunState);
        }
    }

    public override void TickPhysics()
    {
        base.TickPhysics();
    }
}
