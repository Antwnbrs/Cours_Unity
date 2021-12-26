using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifeBar : MonoBehaviour
{
    public Animator HandAnim;
    Rigidbody rb;
    public float playerLife = 100;
    public Image bar;
    public ParticleSystem damageEffectVFX;
    FirstPersonView FirstPersonView;
    public AudioSource playerDeathSFX;
    public AudioSource damageEffectSFX;
    Gun Gun;
    bool playerIsDead = false;
    bool deathSoundPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        FirstPersonView = GameObject.Find("Main Camera").GetComponent<FirstPersonView>();
        Gun = GameObject.Find("Main Camera").GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {

        bar.fillAmount = 0.01f * playerLife;
        if (bar.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (bar.fillAmount < 0.4f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else if (bar.fillAmount < 0.6f)
        {
            SetHealthBarColor(Color.green);
        }
        else
        {
            SetHealthBarColor(Color.cyan);
        }

        if (playerLife <= 0)
        {
            OnDeath();
        }


        if (playerIsDead == true)
        {
            StartCoroutine(ReloadScene());

            if (deathSoundPlayed == false)
            {
                playerDeathSFX.Play();
                deathSoundPlayed = true;
            }
        }
    }

    public void SetHealthBarColor(Color healthColor)
    {
        bar.color = healthColor;
    }

    public void OnDamageReceive()
    {
        damageEffectVFX.Play();
        damageEffectSFX.Play();
    }

    public void OnDeath()
    {
        HandAnim.SetTrigger("Death");
        rb.isKinematic = true;
        FirstPersonView.enabled = false;
        Gun.enabled = false;
        playerIsDead = true;
    }


IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
