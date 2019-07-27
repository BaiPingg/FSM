using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public IState defaultState;
    public IState currentState;
    public List<IState> states = new List<IState>();
    public Dictionary<IState, List<Transition>> transitions = new Dictionary<IState, List<Transition>>();

    public void Init()
    {
        if (states == null)
        {
            Debug.LogError("states is null!!");
            return;
        }
        if (transitions == null)
        {
            Debug.LogError("transition is null!!");
            return;
        }
        if (defaultState == null)
        {
            defaultState = states[0];
        }
        defaultState.StateEnter();
        currentState = defaultState;
    }

    public void FSMUpdate()
    {
        if (currentState == null)
        {
            Debug.LogError("currentstate is null!!!");
            return;
        }

        foreach (var item in transitions[currentState])
        {
            if (item.transition())
            {
                ChangeState(item.to);
            }
        }
        currentState.StateUpdate();
    }

    public void ChangeState(IState state, params object[] parameters)
    {
        currentState.StateEnd();
        state.previousState = currentState;
        state.parameters = parameters;
        currentState = state;
        currentState.StateEnter();
    }

    public void ChangeState(IState state)
    {
        currentState.StateEnd();
        state.previousState = currentState;

        currentState = state;
        currentState.StateEnter();
    }

    public void AddTransition(Transition transition)
    {
        if (!transitions.ContainsKey(transition.from))
        {
            transitions.Add(transition.from, new List<Transition>());
        }
        transitions[transition.from].Add(transition);
    }

    public void AddState(IState state, GameObject obj)
    {
        states.Add(state);
        state.owner = obj;
        if (!transitions.ContainsKey(state))
        {
            transitions.Add(state, new List<Transition>());
        }
    }
}