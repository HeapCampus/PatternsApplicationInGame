using System;
using System.Collections;
using static UnityEngine.GraphicsBuffer;

public interface IColleague
{
    void Notify(Type target, params object[] args);
    void Notify(Type[] targets, params object[] args);
    void OnMessageReceived(params object[] args);
}
