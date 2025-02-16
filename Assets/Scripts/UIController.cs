using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Image hearth1, hearth2, hearth3, hearth4, hearth5;
    public Sprite fullHearth, emptyHearth;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay() {
        switch (CharacterHealthController.instance.currentHealth)
        {
            case 5:
                hearth1.enabled = true;
                hearth2.enabled = true;
                hearth3.enabled = true;
                hearth4.enabled = true;
                hearth5.enabled = true;
                break;
            case 4:
                hearth1.enabled = true;
                hearth2.enabled = true;
                hearth3.enabled = true;
                hearth4.enabled = true;
                hearth5.enabled = false;
                break;
            case 3:
                hearth1.enabled = true;
                hearth2.enabled = true;
                hearth3.enabled = true;
                hearth4.enabled = false;
                hearth5.enabled = false;
                break;
            case 2:
                hearth1.enabled = true;
                hearth2.enabled = true;
                hearth3.enabled = false;
                hearth4.enabled = false;
                hearth5.enabled = false;
                break;
            case 1:
                hearth1.enabled = true;
                hearth2.enabled = false;
                hearth3.enabled = false;
                hearth4.enabled = false;
                hearth5.enabled = false;
                break;
            case 0:
                hearth1.enabled = false;
                hearth2.enabled = false;
                hearth3.enabled = false;
                hearth4.enabled = false;
                hearth5.enabled = false;
                break;
        }
    }
}
