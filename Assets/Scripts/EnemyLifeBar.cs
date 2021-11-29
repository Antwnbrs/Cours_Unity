using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeBar : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    AIMover aimover;
    public float life = 100;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            anim.SetBool("Death", true);
            Destroy(rb);
            Destroy(gameObject, 5);
            if (aimover != null)
            {
                aimover.linearSpeed = 0;
                aimover.angularSpeed = 0;
            }
        }
    }
}
