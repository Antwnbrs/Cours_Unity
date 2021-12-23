using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneScript : MonoBehaviour
{
    public Animator playerHandAnim;
    SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        StartCoroutine(IntroSceneWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IntroSceneWait()
    {
        yield return new WaitForSeconds(7);
        playerHandAnim.SetTrigger("Intro");
        StartCoroutine(WaitForIntroAnim());
    }

    IEnumerator WaitForIntroAnim()
    {
        yield return new WaitForSeconds(10);
        sceneSwitcher.LoadLevel();
    }
}
