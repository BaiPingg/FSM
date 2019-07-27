using UnityEngine;

public class IdleState : IState
{
    public GameObject owner { get; set; }

    public IState previousState { get; set; }
    public object[] parameters { get; set; }

    public void StateEnd()
    {
        Debug.Log("idle end");
    }

    public void StateEnter()
    {
        owner.GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("idle enter");
    }

    public void StateUpdate()
    {
        Debug.Log("idle update");
    }
}