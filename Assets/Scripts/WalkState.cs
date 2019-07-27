using UnityEngine;

public class WalkState : IState
{
    public GameObject owner { get; set; }

    public IState previousState { get; set; }
    public object[] parameters { get; set; }

    public void StateEnd()
    {
        Debug.Log("walk end");
    }

    public void StateEnter()
    {
        Debug.Log(previousState.ToString());
        owner.GetComponent<MeshRenderer>().material.color = Color.blue;
        Debug.Log("walk enter");
    }

    public void StateUpdate()
    {
        Debug.Log("walk update");
    }
}