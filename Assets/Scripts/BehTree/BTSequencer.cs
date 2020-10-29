using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BTSequencer : IState
{
    public string Name { get; }
    private List<IState> states;
    public IState CurrentState { get; set; }
    private int index;

    public Action OnExitState { get; set; }

    public BTSequencer(string name)
    {
        Name = name;
        states = new List<IState>();
    }

    public void AddState(IState state)
    {
        states.Add(state);
    }

    private void NextState()
    {
        CurrentState = null;
        if (states != null && states.Count > 0 && index < states.Count)
        {
            CurrentState = states[index];
            CurrentState?.Start();
            //Debug.Log($"{Name}: {CurrentState.Name}");
        }
        index++;
    }

    public void Start()
    {
        index = 0;
        CurrentState = null;
    }

    public EnumState Execute()
    {
        if (CurrentState == null) NextState();
        if (index > states.Count) return EnumState.Success;
        var state = CurrentState?.Execute() ?? EnumState.Failure;
        if (state == EnumState.Failure) Stop();
        if (state == EnumState.Success) CurrentState = null;
        return state;
    }

    public void Stop()
    {
        CurrentState?.Stop();
    }
}
