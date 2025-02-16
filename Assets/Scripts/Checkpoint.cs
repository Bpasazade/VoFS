using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    [SerializeField] private Color checkpointColor;
    // Start is called before the first frame update

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//(collision.CompareTag("Player"))
        {
            AudioController.instance.PlaySound(11);
            CheckpointController.instance.ResetCheckpoints();
            Debug.Log(gameObject.name);
            spriteRenderer.color = checkpointColor;
            CheckpointController.instance.setRespawnPosition(transform.position);
        }
    }

    public void ResetCheckpoint() {
        spriteRenderer.color = Color.white;
    }
}
