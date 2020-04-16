using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private StateMachine stateMachine;
    private void OnEnable() {
        stateMachine.PlayerDetected += Attack;
    }

    private void OnDisable() {
        stateMachine.PlayerDetected -= Attack;
    }

    private void Attack(Enemy enemy, GameObject target) {
        enemy.GetNavmeshAgent().SetDestination(target.transform.position);
        if ((enemy.GetNavmeshAgent().destination - enemy.transform.position).magnitude < 2) {
            Debug.Log("Enemy came to close");
            Destroy(enemy.gameObject);
        }
    }
}
