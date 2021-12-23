using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour

{
    public float puissance = 30;

    public void OnCollisionEnter(Collision collision)
    {
        EnemyLifeBar other = collision.gameObject.GetComponent<EnemyLifeBar>();
        if (other != null)
        {
            other.life -= puissance;
            puissance = 0;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
