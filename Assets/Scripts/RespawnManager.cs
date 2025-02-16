using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        CharacterHealthController.instance.gameObject.SetActive(false);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(3f);
        CharacterHealthController.instance.gameObject.SetActive(true);
        CharacterHealthController.instance.transform.position = CheckpointController.instance.respawnPosition;
        CharacterHealthController.instance.currentHealth = CharacterHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }

}
