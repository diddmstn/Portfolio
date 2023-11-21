using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager ui;

    AudioSource audioSource;
    public DamageSound damageSound;

    [System.Serializable]
    public class DamageSound
    {
        public AudioClip DrippingLiquid;
        public AudioClip PlayerDamage;
       

    }
    void Awake()
    {
        ui = GameObject.Find("UIManager").GetComponent<UI_Manager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        if(this.gameObject.name=="DrippingOil")
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Life")&& ui.HealthyGage.fillAmount>=0)
        {
            DecreaseHP();
            if (!audioSource.isPlaying&& ui.HealthyGage.fillAmount > 0f)
            {
                audioSource.PlayOneShot(damageSound.PlayerDamage);

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Life")&&this.CompareTag("Dead") )
        {
            ui.HealthyGage.fillAmount = 0;
        }
        
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.Stop();
        
      
    }

    void DecreaseHP()//1 0.2 
    {
        if (ui.HealthyGage.fillAmount> 0f)
        {
            ui.HealthyGage.fillAmount -= 0.2f*Time.deltaTime;
        }
        else if (ui.HealthyGage.fillAmount <= 0f)
        {
            audioSource.Stop();
            ui.Game_Over();
            UI_Manager.NextScene = "Retry";
            Player.Die = true;
        }

    }
}
