using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    //config params
    public Checkpoint[] checkpoints;
    public static CheckpointController instance;

    public Vector3 respawnPosition;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCheckpoints() {
        foreach (Checkpoint checkpoint in checkpoints) {
            checkpoint.ResetCheckpoint();
        }
    }

    public void setRespawnPosition(Vector3 position) {
        respawnPosition = position;
    }
}
