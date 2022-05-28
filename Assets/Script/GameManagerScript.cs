using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void AttackCheck(GameObject attacker)
    {
        if(attacker != player){
            print("Player is attacked by " + attacker.name);
            player.SendMessage("Damage", 10);
        }
    }

    void Block(){

    }
}
