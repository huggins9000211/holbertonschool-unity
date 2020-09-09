using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    float xAxisMv, zAxisMv;
    static float r = 6.25f;
    public float turnSpeed = .01f;
    GameObject player;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        x += Input.GetAxis("Mouse X") * turnSpeed;
        Debug.Log($"test: {x}");
        xAxisMv = r * Mathf.Sin(x);
        zAxisMv = r * Mathf.Cos(x);
        transform.position = new Vector3(player.transform.position.x + xAxisMv, player.transform.position.y + 1.25f, player.transform.position.z + zAxisMv);
        transform.LookAt(player.transform.position);
        
    }
}
