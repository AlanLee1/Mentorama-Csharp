using UnityEngine;

public class Module10_Move : MonoBehaviour
{
    [SerializeField] public float Speed;
    [SerializeField] public float Boost;
    [SerializeField] public Vector3 Direction;

    public Module10_Move(float speed, int boost, Vector3 direction)
    {
        Speed = speed;
        Boost = boost;
        Direction = direction;
    }
    private void FixedUpdate()
    {
        Translate(Direction * Speed * Boost * Time.deltaTime);
    }

    //movement player
    public void Translate(Vector3 translation)
    {
        transform.position = transform.position + translation;
    }
}
