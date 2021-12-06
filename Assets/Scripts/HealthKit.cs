using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour

{
    public float healingPower = 20;
    private Collider healthKitCollider;
    public void OnCollisionEnter(Collision collision)
    {
        PlayerLifeBar other = collision.gameObject.GetComponent<PlayerLifeBar>();
        if (other.playerLife <= 80)
        {
            other.playerLife += healingPower;
            healingPower = 0;
            Destroy(gameObject);
        }
        else
        {
            healthKitCollider.enabled = false;
            StartCoroutine(waitToEnable());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthKitCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitToEnable()
    {
        yield return new WaitForSeconds(1);
        healthKitCollider.enabled = true;
    }
}
