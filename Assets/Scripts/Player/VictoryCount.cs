using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCount : MonoBehaviour
{
    public float EnemiesKilled;
    public float KillGoal;
    InputController inputController;
    SceneSwitcher sceneSwitcher;
    Rigidbody rb;

    void Start()
    {
        inputController = GetComponent<InputController>();
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (EnemiesKilled >= KillGoal)
        {
            Debug.Log("Victory");
            inputController.enabled = false;
            rb.isKinematic = true;
            StartCoroutine(WaitForVictory());
        }
        
    }

    IEnumerator WaitForVictory()
    {
        yield return new WaitForSeconds(5);
        sceneSwitcher.LoadOutro();
    }
}
