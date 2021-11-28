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

        Debug.DrawLine(transform.position, player.position, Color.magenta);
        if (rb != null)
        {
            dirPlayer = player.position - transform.position;
            //dirPlayer = dirPlayer.normalized;

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


        if (life <= 0)
        { 
            anim.SetBool("Death", true);
            Destroy(rb);
            linearSpeed = 0;
            angularSpeed = 0;
            Destroy(gameObject, 5);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other = attackTrigger)
        {
            rb.isKinematic = true;
            anim.SetBool("CanAttack", true);
            WantsToShootPlayer = true;

        }

    }

    void OnTriggerExit(Collider other)
    {
       if (other = attackTrigger)
        {
            anim.SetBool("CanAttack", false);
            rb.isKinematic = false;
            WantsToShootPlayer = false;
        }
      
    }
    /*  private void OnDrawGizmos()
      {
          Gizmos.color = Color.green;
          Gizmos.DrawLine(transform.position, transform.position + dirPlayer);
      } */
} 