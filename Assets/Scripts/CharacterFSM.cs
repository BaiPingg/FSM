using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFSM : MonoBehaviour
{
    public FSM characterFSM;
    public IdleState idleState;
    public WalkState walkState;

    private void Init()
    {
        characterFSM = new FSM();
        idleState = new IdleState();
        walkState = new WalkState();

        characterFSM.AddState(idleState, gameObject);
        characterFSM.AddState(walkState, gameObject);

        Transition idle2walk = new Transition(idleState, walkState);
        idle2walk.transition += idle2WalfTransition;
        characterFSM.AddTransition(idle2walk);

        Transition walk2Idle = new Transition(walkState, idleState);
        walk2Idle.transition += walk2IdleTransition;
        characterFSM.AddTransition(walk2Idle);

        characterFSM.Init();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        characterFSM.FSMUpdate();
    }

    private bool walk2IdleTransition()
    {
        if (GetComponent<CharacterControl>().speed == 0)
        {
            return true;
        }
        return false;
    }

    private bool idle2WalfTransition()
    {
        if (GetComponent<CharacterControl>().speed == 2)
        {
            return true;
        }
        return false;
    }
}