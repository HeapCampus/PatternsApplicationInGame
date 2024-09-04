using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : StatefulBehaviour
{
    public SpeedController SpeedController;
    public Animator Animator;
    public float RunSpeedCondition = 1.5f;
    public IdleState IdleState {  get; private set; }
    public WalkState WalkState { get; private set; }
    public RunState RunState { get; private set; } 
    public JumpState JumpState { get; private set; }
    public AttackState AttackState { get; private set; }  

    private void Awake()
    {
        IdleState = new IdleState(this);
        WalkState = new WalkState(this);
        RunState = new RunState(this);
        JumpState = new JumpState(this);
        AttackState = new AttackState(this);

        InitMachine(IdleState);
    }

    public void ChangeState(IState newState)
    {
        StateMachine.ChangeState(newState);
    }

    protected override void Update()
    {
        base.Update();

        Vector3 translation = Vector3.forward * Time.deltaTime * SpeedController.Speed;
        transform.Translate(translation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(JumpState);
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
             ChangeState(AttackState);
        }
    }
}
