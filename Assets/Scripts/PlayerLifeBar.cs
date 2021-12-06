using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBar : MonoBehaviour
{
    public Animator HandAnim;
    Rigidbody rb;
    public float playerLife = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLife <= 0)
        {
            HandAnim.SetTrigger("Death");
            Debug.Log("Player is dead !");
        }
    }
}
