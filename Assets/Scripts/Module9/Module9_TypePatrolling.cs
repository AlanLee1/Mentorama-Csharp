using System.Collections.Generic;
using UnityEngine;

public class Module9_TypePatrolling : MonoBehaviour
{
    private enum EnemyState
    {
        Stopped,
        Patrolling
    }

    public Module9_Patrol PatrolComponent;

    [SerializeField] List<Module9_PatrolData> listPatrolData = new List<Module9_PatrolData>();

    private EnemyState _currentEnemyState;
    private int typePatrol;

    private void Start()
    {
        _currentEnemyState = EnemyState.Stopped;
        typePatrol = 0;
        listPatrolData.Add(new Module9_PatrolData() { MoveSpeed = 1, MovelDuration = 3, IdleDuration = 1 });
        listPatrolData.Add(new Module9_PatrolData() { MoveSpeed = 2, MovelDuration = 6, IdleDuration = 2 });
        listPatrolData.Add(new Module9_PatrolData() { MoveSpeed = 3, MovelDuration = 9, IdleDuration = 1 });
        listPatrolData.Add(new Module9_PatrolData() { MoveSpeed = 4, MovelDuration = 12, IdleDuration = 2 });
    }

    private void Update()
    {

        AlterRotine();
        PatrollingState();

    }

    private void PatrollingState()
    {
        //Estado: patrulhando ou parado
        switch (_currentEnemyState)
        {
            default:
            case EnemyState.Stopped:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PatrolComponent.StartPatrolling(listPatrolData[typePatrol]);
                    _currentEnemyState = EnemyState.Patrolling;
                }
                break;

            case EnemyState.Patrolling:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PatrolComponent.StopPatrolling();
                    _currentEnemyState = EnemyState.Stopped;
                }
                break;
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

}