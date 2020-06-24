﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackState : StateMachineBehaviour
{
    TurretScript turretScript;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       turretScript = animator.gameObject.GetComponent<TurretScript>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 turretPos = turretScript.turretHinge.position;
        turretPos.y = 0;

        Vector3 targetPos = turretScript.target.position;
        targetPos.y = 0;

        Quaternion targetDirection = Quaternion.LookRotation(targetPos - turretPos, Vector3.up);

        float step = Time.deltaTime * 100f;
        turretScript.turretHinge.rotation = Quaternion.RotateTowards(turretScript.turretHinge.rotation, targetDirection, step);
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
