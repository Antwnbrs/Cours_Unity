using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    public AIMoverFire AIController;
    public EnemyLifeBar lifebar;
    public Transform PrefabProjectile;
    public float ProjectileStartSpeed = 50;
    public float OffsetForwardShoot = 2;
    public float TimeBetweenShots = 0.5f;
    private float TimeShoot = 0;
    public Transform firingPoint;
    public AudioSource firingSound;

    void Update()
    {
        TimeShoot -= Time.deltaTime;

        if (AIController.WantsToShootPlayer && TimeShoot <= 0 && lifebar.life >0)
        {
            TimeShoot = TimeBetweenShots;

            Transform proj = GameObject.Instantiate<Transform>(PrefabProjectile,
            firingPoint.position + -firingPoint.forward * OffsetForwardShoot, firingPoint.rotation);

            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileStartSpeed, ForceMode.Impulse);
           // firingSound.Play();
        }
    }
}