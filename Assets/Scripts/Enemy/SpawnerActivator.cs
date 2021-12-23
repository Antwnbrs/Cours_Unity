using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    public AISpawner spawnerToActivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "RealPlayer")
        {
            spawnerToActivate.enabled=true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
