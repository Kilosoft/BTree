using System;
using UnityEngine;

[Serializable]
public class BTAction : IState
{
    public string Name { get; }

    public Action OnExitState { get; set; }

    public Action Func = delegate { };

    public IState CurrentState { get; set; }

    public BTAction(string name, Action func)
    {
        Name = name;
        Func = func;
    }

    public void Start()
    {
        
    }

    public EnumState Execute()
    {
        Func?.Invoke();
        if (Func == null) return EnumState.Failure;
        return EnumState.Success;
    }

    public void Stop()
    {

    }
}