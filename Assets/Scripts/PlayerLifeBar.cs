using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeBar : MonoBehaviour
{
    public float playerLife = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLife <= 0)
        {
            Debug.Log("Player is dead !");
        }
    }
}
