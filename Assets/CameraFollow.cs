using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject follow;
    public Vector2 minCampo, maxCampo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
        
    {
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(
            Mathf.Clamp(posX, minCampo.x, maxCampo.x),
            Mathf.Clamp(posY, minCampo.y, maxCampo.y),
            transform.position.z);
    }
}
