using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        Translate(Vector3.right * speed * Time.deltaTime);
    }

    //movement player
    public void Translate(Vector3 translation)
    {
        transform.position = transform.position + translation;
    }
}
