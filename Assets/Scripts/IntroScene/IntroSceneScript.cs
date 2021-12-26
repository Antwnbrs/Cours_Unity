using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSceneScript : MonoBehaviour
{
    public Animator playerHandAnim;
    SceneSwitcher sceneSwitcher;
    public Animator EnemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>();
        StartCoroutine(IntroSceneWait());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAnim.SetFloat("Speed", 1);
    }

    IEnumerator IntroSceneWait()
    {
        yield return new WaitForSeconds(15);
        playerHandAnim.SetTrigger("Intro");
        StartCoroutine(WaitForIntroAnim());
    }

    IEnumerator WaitForIntroAnim()
    {
        yield return new WaitForSeconds(10);
        sceneSwitcher.LoadLevel();
    }
}
