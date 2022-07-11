using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] public Move MoveComponent;

    private void Start()
    {
        MoveComponent.Speed = 1.5f;
        MoveComponent.Direction = Vector3.zero;
    }

    private void Update()
    {
        Moviment();
    }

    private void Moviment()
    {
        MoveComponent.Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            MoveComponent.Direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveComponent.Direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveComponent.Direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveComponent.Direction += Vector3.right;
        }
    }
}
