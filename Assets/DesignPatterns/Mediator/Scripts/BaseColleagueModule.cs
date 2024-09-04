using System;
using UnityEngine;

public abstract class BaseColleagueModule : MonoBehaviour, IColleague
{
    protected IMediator _mediator;

    protected virtual void Awake()
    {
        _mediator = FindAnyObjectByType<ConcreteMediator>();
        _mediator.RegisterModule(this);
    }

    public void Notify(Type target, params object[] args)
    {
        _mediator.Notify(this, target, args);
    }

    public void Notify(Type[] targets, params object[] args)
    {
        _mediator.Notify(this, targets, args);
    }

    public abstract void OnMessageReceived(params object[] args);
}
