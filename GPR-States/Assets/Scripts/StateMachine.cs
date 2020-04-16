using UnityEngine;
using System;
using System.Collections;

public class StateMachine : MonoBehaviour
{
    public event Action<Enemy, GameObject> PlayerDetected;
    public event Action<Enemy> PlayerUndetected;
    public event Action<Enemy> AttackPlayer;
    [SerializeField] private Enemy enemy;
    private GameObject currentTarget;
    public enum EnemyStates {
        IDLE,
        CHASE,
        ATTACK
    }

    EnemyStates currentState = EnemyStates.IDLE;
    // Update is called once per frame
    void Update() {
        switch (currentState) {
            case EnemyStates.ATTACK:
                AttackPlayer?.Invoke(enemy);
                break;
            case EnemyStates.CHASE:
                PlayerDetected?.Invoke(enemy, currentTarget);
                break;
            case EnemyStates.IDLE:
                PlayerUndetected?.Invoke(enemy);
                break;
        }
    }

    public void ChangeState(EnemyStates state, GameObject target = null) {
        currentState = state;
        if (target) {
            currentTarget = target;
        }
    }

    public EnemyStates GetState()
    {
        return currentState;
    }
}
