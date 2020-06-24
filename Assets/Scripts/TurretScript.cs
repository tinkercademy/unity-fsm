using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform turretHinge;
    public Transform target;
    private Animator animator;
    private float distance;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector3.Distance(turretHinge.position, target.position);
        animator.SetFloat("Distance", distance);
    }
}
