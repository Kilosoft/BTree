using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BTSelector : IState
{
    public string Name { get; }
    public List<IState> states;
    public IState CurrentState { get; set; }
    public int index;

    public Action OnExitState { get; set; }

    public BTSelector(string name)
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
            CurrentState.Start();
            Debug.Log($"{Name}: {CurrentState.Name}");
            index++;
        }
    }

    public void Start()
    {
        index = 0;
        CurrentState = null;
    }

    public EnumState Execute()
    {
        var state = EnumState.Failure;
        for (int i = 0; i < states.Count; i++)
        {
            CurrentState = states[i];
            state = CurrentState.Execute();
            //Debug.Log($"{Name}: {CurrentState.Name} {state}");
            if (state == EnumState.Success || state == EnumState.Running)
            {
                return state;
            }
            else
            {
                CurrentState = null;
            }
        }
        return state;
    }

    public void Stop()
    {
        CurrentState?.Stop();
    }
}