using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCount : MonoBehaviour
{
    Gun playerGun;
    public float EnemiesKilled;
    public float KillGoal;
    InputController inputController;
    SceneSwitcher sceneSwitcher;
    Rigidbody rb;
    Light directionalLight;

    void Start()
    {
        playerGun = GetComponentInChildren<Gun>();
        inputController = GetComponent<InputController>();
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        rb = GetComponentInChildren<Rigidbody>();
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if (EnemiesKilled >= KillGoal)
        {
            // Debug.Log("Victory");
            inputController.enabled = false;
            rb.isKinematic = true;
            playerGun.enabled = false;
            LightIntensity();
            StartCoroutine(WaitForVictory());
        }
        
    }

    void LightIntensity()
    {
        directionalLight.intensity = Mathf.Lerp(0.01f, 150f, Time.time / 25);
        Debug.Log("LightIntensity =" + directionalLight.intensity + Time.time);

    }
        IEnumerator WaitForVictory()
    {
        yield return new WaitForSeconds(2);
        sceneSwitcher.LoadOutro();
    }
}
