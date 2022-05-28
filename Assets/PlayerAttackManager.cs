using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public int hp = 100;

    void Damage (int damage) {
        hp -= damage;
        if(hp <= 0f){
            Destroy(this.gameObject);
        }
    }
}
