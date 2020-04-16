using UnityEngine;
using System;
using System.Collections;

public class StateMachine : MonoBehaviour
{
    public event Action<Enemy, GameObject> PlayerDetected;
    public event Action<Enemy> PlayerUndetected;
    [SerializeField] private Enemy enemy;
    private GameObject currentTarget;
    public enum EnemyStates {
        IDLE,
        ATTACK
    }

    EnemyStates currentState = EnemyStates.IDLE;
    // Update is called once per frame
    void Update() {
        switch (currentState) {
            case EnemyStates.ATTACK:
                PlayerDetected?.Invoke(enemy,currentTarget);
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
}
