using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    [Tooltip("Vitesse de déplacement"), Range(1, 15)]
    public float linearSpeed = 6;
    [Tooltip("Vitesse de rotation"), Range(0, 5)]
    public float angularSpeed = 1; 

    private Transform player;
    public Vector3 dirPlayer;
    public float life = 100;
    private Rigidbody rb;
    Animator anim;
    public Collider attackTrigger;
    public float damage = 20;

    public bool WantsToShootPlayer { get; protected set; } = false;

    public void Start()
    {
        GameObject goPlayer = GameObject.Find("Karl");
        player = goPlayer.transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        // Debug.DrawLine(transform.position, player.position, Color.magenta);
        if (rb != null)
        {
            dirPlayer = player.position - transform.position;

            dirPlayer.y = 0;
            Quaternion rotation = Quaternion.LookRotation(dirPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, angularSpeed);

            if (rb.velocity.magnitude < 10)
            {
                rb.AddForce(transform.forward * 5 * linearSpeed);
            }

            if (anim != null)
            {
                anim.SetFloat("Speed", rb.velocity.magnitude);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerLifeBar other = collision.gameObject.GetComponent<PlayerLifeBar>();
        if (other.playerLife >= 1)
        {
            other.playerLife -= damage;
            damage = 0;
            rb.AddForce(transform.forward*-1000);
            other.OnDamageReceive();
                        
            StartCoroutine(DmgReset());
        }
    }

    
    IEnumerator DmgReset()
    {
        yield return new WaitForSeconds(1);
        damage = 20;
    }
} 