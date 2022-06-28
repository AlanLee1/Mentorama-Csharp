using System;
using System.Collections.Generic;
using UnityEngine;

public class Module6 : MonoBehaviour
{
    //enum é uma estrutura de constantes
    enum EnemyState
    {
        Stopped,
        Patrolling
        //Patrolling1,
        //Patrolling2
    }

    enum PatrolDirection
    {
        Left,
        Right,
        Top,
        Bottom
    }

    [Serializable]
    struct PatrolData
    {
        public float PatrolDuration;
        public float MoveSpeed;
        public float MoveDirectionDuration;
        public float StayDuration;
    }

    //Variaveis
    [SerializeField] EnemyState currentEnemyState;
    //[SerializeField] PatrolData patrolData1;
    //[SerializeField] PatrolData patrolData2;
    [SerializeField] List<PatrolData> listPatrolData = new List<PatrolData>();
    [SerializeField] PatrolDirection currentPatrolDirection;
    private float directionChangeTime;
    private float startpatrolTime;
    private int typePatrol;


    //Inicializando
    void Start()
    {
        currentEnemyState = EnemyState.Stopped;
        currentPatrolDirection = PatrolDirection.Right;
        directionChangeTime = 0;
        typePatrol = 0;
        listPatrolData.Add(new PatrolData() { PatrolDuration = 8, MoveSpeed = 1, MoveDirectionDuration = 1.5f, StayDuration = 0.25f });
        listPatrolData.Add(new PatrolData() { PatrolDuration = 12, MoveSpeed = 2, MoveDirectionDuration = 2f, StayDuration = 0.5f });
        listPatrolData.Add(new PatrolData() { PatrolDuration = 12, MoveSpeed = 3, MoveDirectionDuration = 2.5f, StayDuration = 0.25f });
        listPatrolData.Add(new PatrolData() { PatrolDuration = 16, MoveSpeed = 4, MoveDirectionDuration = 3f, StayDuration = 0.5f });
    }

    //Cada frame
    void Update()
    {

        AlterRotine();
        ChangeEnemyState();

    }

    private void ChangeEnemyState()
    {
        //Estado: patrulhando ou parado
        switch (currentEnemyState)
        {
            default:
            case EnemyState.Stopped:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentEnemyState = EnemyState.Patrolling;
                    startpatrolTime = Time.time;
                }
                break;

            case EnemyState.Patrolling:

                if (Time.time > startpatrolTime + listPatrolData[typePatrol].PatrolDuration)
                {
                    currentEnemyState = EnemyState.Stopped;
                    startpatrolTime = Time.time;
                } else
                {
                    PatrolRotine(listPatrolData[typePatrol]);
                }
                break;


                /*
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
                */
        }
    }

    private void AlterRotine()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (typePatrol == 3)
            {
                typePatrol = 0;
                Debug.Log($"typePatrol: {typePatrol}");
            } else
            {
                typePatrol++;
                Debug.Log($"typePatrol: {typePatrol}");
                typePatrol = Mathf.Clamp(typePatrol, 0, 4);
            }
        }
    }

    //Patrol Rotine
    private void PatrolRotine(PatrolData patrolData)
    {
        directionChangeTime += Time.deltaTime;

        //Direcao da patrulha
        switch (currentPatrolDirection)
        {
            case PatrolDirection.Right:
                ChangePatrolDirection(patrolData, PatrolDirection.Top);
                //patrol move
                Translate(new Vector3(patrolData.MoveSpeed * Time.deltaTime, 0, 0));
                break;

            case PatrolDirection.Top:
                ChangePatrolDirection(patrolData, PatrolDirection.Left);
                //patrol move
                Translate(new Vector3(0, 0, patrolData.MoveSpeed * Time.deltaTime));
                break;


            case PatrolDirection.Left:
                ChangePatrolDirection(patrolData, PatrolDirection.Bottom);
                //patrol move
                Translate(new Vector3(-patrolData.MoveSpeed * Time.deltaTime, 0, 0));
                break;


            case PatrolDirection.Bottom:
                ChangePatrolDirection(patrolData, PatrolDirection.Right);
                //patrol move
                Translate(new Vector3(0, 0, -patrolData.MoveSpeed * Time.deltaTime));
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

    //movement player
    void Translate(Vector3 translation)
    {
        transform.position = transform.position + translation;
    }
}
