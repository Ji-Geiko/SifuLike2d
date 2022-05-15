using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutScript : MonoBehaviour
{
    public GameObject player;
    public float closeRange = 1.5f;
    public float[] attackRange = new float[2];
    public float longRange  = 10f;
    public string state = "idle";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackRange[0] = 1.5f;
        attackRange[1] = 2f;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance >= attackRange[0] && distance <= attackRange[1])
        {
            print("attack");
            state = "attack";
        }
        else if(distance < closeRange)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            state = "close";
        }
        else if(distance < longRange)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            state = "long";
        }else
        {
            state = "idle";
        }
        print(Vector3.Distance(transform.position, player.transform.position));
    }
}
