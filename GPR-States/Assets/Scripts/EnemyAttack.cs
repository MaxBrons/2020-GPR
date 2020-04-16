using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private StateMachine stateMachine;
    private void OnEnable() {
        stateMachine.AttackPlayer += Attack;
    }

    private void OnDisable() {
        stateMachine.AttackPlayer -= Attack;
    }

    private void Attack(Enemy enemy) {
        Debug.Log("Enemy came to close");
        Destroy(enemy.gameObject);
    }
}
