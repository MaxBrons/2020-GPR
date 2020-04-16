using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private StateMachine stateMachine;
    void Update()
    {
        Collider[] inRangeObjects = Physics.OverlapSphere(transform.position, 25, layerMask);
        if (inRangeObjects.Length > 0) {
            if (stateMachine.GetState() != StateMachine.EnemyStates.ATTACK) {
                stateMachine?.ChangeState(StateMachine.EnemyStates.CHASE,inRangeObjects[0].gameObject);
            }
        }
        else {
            stateMachine.ChangeState(StateMachine.EnemyStates.IDLE);
        }
    }
}
