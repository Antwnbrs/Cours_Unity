using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballEnemy : MonoBehaviour

{
    public float damage = 30;

    public void OnCollisionEnter(Collision collision)
    {
        PlayerLifeBar other = collision.gameObject.GetComponent<PlayerLifeBar>();
        if (other.playerLife >= 1)
        {
            other.playerLife -= damage;
            damage = 0;
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
