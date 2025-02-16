using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public static CharacterHealthController instance;
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
            AudioController.instance.PlaySound(3);
            currentHealth--;
            if (currentHealth <= 0) {

                currentHealth = 0;
                //gameObject.SetActive(false);
                AudioController.instance.PlaySound(0);
                RespawnManager.instance.Respawn();
            }
            takeDamageCounter = takeDamageTime;
            theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.5f);
        }
        UIController.instance.UpdateHealthDisplay();
    }

    public void Heal(int amountToHeal) {
        currentHealth += amountToHeal;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
