using System;
using UnityEngine;

public class Module6 : MonoBehaviour
{
    //enum é uma estrutura de constantes
    enum EnemyState
    {
        Stopped,
        Patrolling1,
        Patrolling2
    }

    enum PatrolDirection
    {
        Left,
        Right
    }

    [Serializable]
    struct PatrolData
    {
        public float PatrolDuration;
        public float MoveSpeed;
        public float MoveDirectionDuration;
    }

    //Variaveis
    [SerializeField] EnemyState currentEnemyState;
    [SerializeField] PatrolData patrolData1;
    [SerializeField] PatrolData patrolData2;
    [SerializeField] PatrolDirection currentPatrolDirection;
    private float directionChangeTime;
    private float startpatrolTime;


    //Inicializando
    void Start()
    {
        currentEnemyState = EnemyState.Stopped;
        currentPatrolDirection = PatrolDirection.Right;
        directionChangeTime = 0;
    }

    //Cada frame
    void Update()
    {
        //Estado: patrulhando ou parado
        switch (currentEnemyState)
        {
            default:
            case EnemyState.Stopped:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentEnemyState = EnemyState.Patrolling1;
                    startpatrolTime = Time.time;
                }
                break;

            case EnemyState.Patrolling1:
                if (Time.time > startpatrolTime + patrolData1.PatrolDuration)
                {
                    currentEnemyState = EnemyState.Patrolling2;
                    startpatrolTime = Time.time;
                } else
                {
                    PatrolRotine(patrolData1);
                }
                break;
            
            case EnemyState.Patrolling2:
                if (Time.time > startpatrolTime + patrolData2.PatrolDuration)
                {
                    currentEnemyState = EnemyState.Stopped;
                } else
                {
                    PatrolRotine(patrolData2);
                }
                break;
        }

    }

    private void PatrolRotine(PatrolData patrolData)
    {
        directionChangeTime += Time.deltaTime;

        //Direcao da patrulha
        switch (currentPatrolDirection)
        {
            case PatrolDirection.Right:
                ChangePatrolDirection(patrolData, PatrolDirection.Left);
                //patrol move
                Translate(new Vector3(patrolData.MoveSpeed * Time.deltaTime, 0, 0));


                break;


            case PatrolDirection.Left:
                ChangePatrolDirection(patrolData, PatrolDirection.Right);
                //patrol move
                Translate(new Vector3(-patrolData.MoveSpeed * Time.deltaTime, 0, 0));
                break;
        }
    }

    //change patrol direction
    private void ChangePatrolDirection(PatrolData patrolData, PatrolDirection newPatrolDirection)
    {
        if (directionChangeTime > patrolData.MoveDirectionDuration)
        {
            currentPatrolDirection = newPatrolDirection;
            directionChangeTime = 0;
        }
    }

    void Translate(Vector3 translation)
    {
        transform.position = transform.position + translation;
    }
}
