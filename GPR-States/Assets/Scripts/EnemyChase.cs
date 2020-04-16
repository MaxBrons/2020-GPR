using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{

    [SerializeField] private StateMachine stateMachine;
    private void OnEnable() {
        stateMachine.PlayerDetected += Chase;
    }

    private void OnDisable() {
        stateMachine.PlayerDetected -= Chase;
    }

    private void Chase(Enemy enemy, GameObject target) {
        enemy.GetNavmeshAgent().SetDestination(target.transform.position);
        if ((target.transform.position - enemy.transform.position).magnitude < 1.5) {
            stateMachine.ChangeState(StateMachine.EnemyStates.ATTACK);
        }
    }
}
