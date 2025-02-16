using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource[] audioSource;
    // Start is called before the first frame update
    
    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        audioSource[index].Stop();
        audioSource[index].Play();
    }

    public void StopSound(int index)
    {
        audioSource[index].Stop();
    }
}
