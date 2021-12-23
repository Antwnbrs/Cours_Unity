using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroSceneScript : MonoBehaviour
{
    public Canvas OutroUI;
    // Start is called before the first frame update
    void Start()
    {
        OutroUI.enabled = false;
        Debug.Log("Starting Coroutine...");
        StartCoroutine(WaitForOutroAnim());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForOutroAnim()
    {
        yield return new WaitForSeconds(13);
        OutroUI.enabled = true;
        Debug.Log("UI is enabled.");
    }
}
