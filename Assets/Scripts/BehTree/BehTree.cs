using System.Collections.Generic;
using UnityEngine;

public class BehTree : MonoBehaviour
{
    public List<IState> states;
    public IState currenState;
    private int index;

    public string nameState;

    public void AddState(IState state)
    {
        if (states == null) states = new List<IState>();
        states.Add(state);
    }

    private void NextState()
    {
        currenState?.Stop();
        if (states != null && states.Count > 0 && states.Count > index)
        {
            currenState = states[index];
            currenState.Start();
            index++;
            if (index >= states.Count) index = 0;
        }
    }

    private void Update()
    {
        if (currenState == null) NextState();

        nameState = "";
        var statef = currenState;
        while (statef != null)
        {
            if (statef != null)
            {
                nameState += $"[{statef.Name}] {(statef.CurrentState != null ? "->" : "")}";
            }
            statef = statef.CurrentState;
        }

        var state = currenState?.Execute() ?? EnumState.Failure;
        if (state == EnumState.Failure)
        {
            currenState?.Stop();
            currenState = null;
        }
    }
}
