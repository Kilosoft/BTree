using System;
using UnityEngine;

[Serializable]
public class BTCondition : IState
{
    public string Name { get; }
    public Action OnExitState { get; set; }

    private Func<bool> Func;

    public IState CurrentState { get; set; }

    public BTCondition(string name, Func<bool> func)
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
        //Debug.Log($"{Name}: {result} {(result ? EnumState.Success : EnumState.Failure)}");
        return result ? EnumState.Success : EnumState.Failure;
    }

    public void Stop()
    {

    }
}
