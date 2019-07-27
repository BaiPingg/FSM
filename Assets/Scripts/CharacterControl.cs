using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += speed * transform.forward * Time.deltaTime;
    }

    public void OnIdlePressed()
    {
        speed = 0;
    }

    public void OnWalkPressed()
    {
        speed = 2;
    }
}