using System;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteMediator : MonoBehaviour, IMediator
{
    private List<IColleague> _colleagues = new List<IColleague>();

    public void Notify(object sender, Type target, params object[] args)
    {
        foreach (var colleague in _colleagues)
        {
            if(colleague.GetType() == target)
            {
                colleague.OnMessageReceived(args);
            }
        }
    }

    public void Notify(object sender, Type[] targets, params object[] args)
    {
        foreach (var colleague in _colleagues)
        {
            foreach (var target in targets)
            {
                if (colleague.GetType() == target)
                {
                    colleague.OnMessageReceived(args);
                }
            }

        }
    }

    public void RegisterModule(IColleague module)
    {
        if (!_colleagues.Contains(module))
        {
            _colleagues.Add(module);
        }
    }
}
