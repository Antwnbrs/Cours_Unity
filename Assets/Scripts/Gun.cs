using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Controller MyController;
    public Transform PrefabProjectile;
    public float ProjectileStartSpeed = 50;
    public float OffsetForwardShoot = 2;
    public float TimeBetweenShots = 0.5f;
    private float TimeShoot = 0;
    public Transform fingerGun;
    public Animator Animator;
    public AudioSource firingSound;

    void Update()
    {
        TimeShoot -= Time.deltaTime;

        if (MyController.WantsToShoot && TimeShoot <= 0)
        {
            TimeShoot = TimeBetweenShots;

            Transform proj = GameObject.Instantiate<Transform>(PrefabProjectile,
            fingerGun.position + fingerGun.forward * OffsetForwardShoot, fingerGun.rotation);

            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileStartSpeed, ForceMode.Impulse);
            Animator.SetTrigger("Fire");
            firingSound.Play();
        }
    }
}