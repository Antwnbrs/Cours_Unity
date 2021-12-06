using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar : MonoBehaviour
{
    public Animator HandAnim;
    Rigidbody rb;
    public float playerLife = 100;
    public Image bar;
    public ParticleSystem damageEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
            HandAnim.SetTrigger("Death");
            Debug.Log("Player is dead !");
        }
    }

    public void SetHealthBarColor(Color healthColor)
    {
        bar.color = healthColor;
    }

    public void OnDamageReceive ()
    {
        damageEffect.Play();
    }
}
