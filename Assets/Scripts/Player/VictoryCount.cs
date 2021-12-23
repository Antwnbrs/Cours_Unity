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

    void Start()
    {
        inputController = GetComponent<InputController>();
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (EnemiesKilled >= KillGoal)
        {
            Debug.Log("Victory");
            inputController.enabled = false;
            StartCoroutine(WaitForVictory());
        }
        
    }

    IEnumerator WaitForVictory()
    {
        yield return new WaitForSeconds(5);
        sceneSwitcher.LoadOutro();
    }
}
