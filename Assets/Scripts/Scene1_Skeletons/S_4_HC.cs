using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_4_HC : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static S_4_HC instance;
    public float takeDamageTime = 2f;
    public float takeDamageCounter = 0f, transparentCounter = 0f;
    private SpriteRenderer theSprite;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
            if (currentHealth <= 0) {

                currentHealth = 0;
                Debug.Log("Enemy is dead");

                S_4_C.instance.animator.SetBool("player_in", false);
                S_4_C.instance.animator.SetBool("isDead", true);
        
                //AudioController.instance.PlayMusic(1);
            }
            takeDamageCounter = takeDamageTime;
            theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        }
    }
}
