using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //config params
    public Transform player;
    public Transform background;
    private Vector2 lastPosXY;
    public float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        lastPosXY = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minX, maxX), Mathf.Clamp(player.position.y, minY, maxY), transform.position.z);
        
        Vector2 delta = new Vector2(transform.position.x - lastPosXY.x, transform.position.y - lastPosXY.y);
        background.position += new Vector3(delta.x, delta.y, 0f);
        //middle_far.position += new Vector3(delta.x, delta.y, 0f) * 0.5f;
        
        lastPosXY = transform.position;
    }
}

