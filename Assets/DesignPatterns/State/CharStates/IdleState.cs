using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateTemplate<Character>
{
    public IdleState(Character entity) : base(entity)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        if (Entity.StateMachine.GetPreviousState() != null)
        {
            Entity.Animator.SetTrigger("idle");
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        base.Tick();

        if(Entity.SpeedController.Speed > 0)
        {
            Entity.ChangeState(Entity.WalkState);
        }
    }

    public override void TickPhysics()
    {
        base.TickPhysics();
    }
}
