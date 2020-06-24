using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform turretHinge;
    public Transform target;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    private Animator animator;
    private float distance;
    private ParticleSystem particle;
    private float t;

    void Awake()
    {
        animator = GetComponent<Animator>();
        particle = GetComponentInChildren<ParticleSystem>();

        t = 0;
    }

    void Update()
    {
        distance = Vector3.Distance(turretHinge.position, target.position);
        animator.SetFloat("Distance", distance);

        t += Time.deltaTime;
    }

    public void Fire()
    {
        if (t < 1f) return;
        t = 0;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, turretHinge.rotation);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100f);
        Destroy(bullet, 5);

        particle.Play();
    }
}
