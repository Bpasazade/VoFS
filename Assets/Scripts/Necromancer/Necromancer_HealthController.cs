using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer_HealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static Necromancer_HealthController instance;
    public float takeDamageTime = 2f;
    public float takeDamageCounter = 0f, transparentCounter = 0f;
    private SpriteRenderer theSprite;

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        takeDamageCounter -= Time.deltaTime;
        if (takeDamageCounter > 0) {
            theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);

        } 
    }

    public void TakeDamage() {

        if (takeDamageCounter <= 0) {
            AudioController.instance.PlaySound(9);
            currentHealth--;
            if(currentHealth == 6) {
                AudioController.instance.PlaySound(7);
            }
            if (currentHealth <= 0) {

                currentHealth = 0;
                AudioController.instance.PlaySound(6);
                Debug.Log("Enemy is dead");

                Necromancer_Controller.instance.animator.SetBool("player_in", false);
                Necromancer_Controller.instance.animator.SetBool("isDead", true);
        
                //AudioController.instance.PlayMusic(1);
            }
            takeDamageCounter = takeDamageTime;
            theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        }
    }
}
