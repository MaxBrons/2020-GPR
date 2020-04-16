using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour
{

    [SerializeField] private StateMachine stateMachine;
    private void OnEnable() {
        stateMachine.PlayerUndetected += Idle;
    }

    private void OnDisable() {
        stateMachine.PlayerUndetected -= Idle;
    }

    private void Idle(Enemy enemy) {
        enemy?.GetNavmeshAgent().SetDestination(enemy.transform.position + new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15)));
    }
}
