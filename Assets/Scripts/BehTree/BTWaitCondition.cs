using System;
using UnityEngine;

[Serializable]
public class BTWaitCondition : IState
{
    public string Name { get; }
    public Action OnExitState { get; set; }

    private Func<bool> Func;

    public IState CurrentState { get; set; }

    public BTWaitCondition(string name, Func<bool> func)
    {
        Name = name;
        Func = func;
    }

    public void Start()
    {

    }

    public EnumState Execute()
    {
        var result = Func?.Invoke() ?? false;
        return result ? EnumState.Success : EnumState.Running;
    }

    public void Stop()
    {

    }
}
