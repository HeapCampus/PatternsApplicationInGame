using System;

public interface IMediator
{
    void RegisterModule(IColleague module);
    void Notify(object sender, Type target, params object[] args);
    void Notify(object sender, Type[] targets, params object[] args);
}
