using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IState
{
    GameObject owner { get; set; }
    IState previousState { get; set; }
    object[] parameters { get; set; }

    void StateEnter();

    void StateUpdate();

    void StateEnd();
}