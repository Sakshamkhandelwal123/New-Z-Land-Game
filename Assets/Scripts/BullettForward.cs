using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullettForward : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float speed = 10.0f;
    void Start()
    {
        // ransform.position = player.transfortm.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(player.transform.forward * Time.deltaTime * speed);
    }
}
