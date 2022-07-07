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
        if (Input.GetKey(KeyCode.W))
        {
            MoveComponent.Translate(Vector3.forward * MoveComponent.Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveComponent.Translate(Vector3.back * MoveComponent.Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveComponent.Translate(Vector3.left * MoveComponent.Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveComponent.Translate(Vector3.right * MoveComponent.Speed * Time.deltaTime);
        }

    }

}
