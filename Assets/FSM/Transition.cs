using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transition
{
    public IState from { get; set; }
    public IState to { get; set; }

    public Func<bool> transition;

    public Transition(IState from, IState to)
    {
        this.from = from;
        this.to = to;
    }
}