using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Module10_Patrol : MonoBehaviour
{
    [SerializeField] private List<Module10_PatrolData> listPatrols = new List<Module10_PatrolData>();
    [SerializeField] private Module10_Move _moveComponent;
    [SerializeField] private int patrol;
    [SerializeField] private Text texto;


    void Start()
    {
        patrol = 0;
        texto.GetComponent<Text>().text = $"{patrol}";
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 1, MoveSpeed = 6, Boost = 1, MoveDirection = Vector3.forward });
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 2, MoveSpeed = 6, Boost = 1.5f, MoveDirection = Vector3.left });
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 3, MoveSpeed = 6, Boost = 1.5f, MoveDirection = Vector3.forward });
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 4, MoveSpeed = 6, Boost = 3, MoveDirection = Vector3.right });
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 5, MoveSpeed = 6, Boost = 2.5f, MoveDirection = Vector3.back });
        listPatrols.Add(new Module10_PatrolData() { CheckPoint = 6, MoveSpeed = 6, Boost = 1.5f, MoveDirection = Vector3.left });
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PatrolMovimentDirection(patrol);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Colisao com o checkpoint
        if (collision.collider.CompareTag("CheckPoint"))
        {
            if (patrol < 5)
            {
                patrol++;
            } else
            {
                patrol = 0;
            }
            texto.GetComponent<Text>().text = $"{patrol}";
        }
    }

    private void PatrolMovimentDirection(int patrol)
    {
        _moveComponent.Speed = listPatrols[patrol].MoveSpeed;
        _moveComponent.Boost = listPatrols[patrol].Boost;
        _moveComponent.Direction = listPatrols[patrol].MoveDirection;
    }
}
