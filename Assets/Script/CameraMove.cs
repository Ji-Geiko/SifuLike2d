using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(player){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3.7f, -10);
        }
    }
}
