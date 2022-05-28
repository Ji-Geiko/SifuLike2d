using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public float[] attackRange = new float[2];
    public int agroRange = 10;
    public Animator animator;
    public bool reloading = false;
    public float reloadTime = 2.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        attackRange[0] = 1.5f;
        attackRange[1] = 2f;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance<=agroRange){
            if(distance > attackRange[0] && distance < attackRange[1] && !reloading)
            {
                Attack();
            }
            else if(distance < attackRange[0] || reloading)
            {
                transform.Translate(Vector3.right * Time.deltaTime * (transform.position.x - player.transform.position.x)/distance);
                print("close " + distance);
            }
            else if(distance > attackRange[1])
            {
                reloading = false;
                transform.Translate(Vector3.left * Time.deltaTime * (transform.position.x - player.transform.position.x)/distance);
                print("long " + distance);
            }
        }

        if(reloading){
            reloadTime-=Time.deltaTime;
        }
        if(reloadTime <= 0)
        {
            reloadTime = 1.0f;
            reloading = false;
        }
    }

    void Attack()
    {
        animator.SetBool("Attack", true);
        if(player.transform.position.x<transform.position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,player.transform.position.y), 0.5f * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x,player.transform.position.y), 0.5f * Time.deltaTime);
        }
    }

    void Damage()
    {
        animator.SetBool("Attack", false);
        gameManager.SendMessage("AttackCheck", this.gameObject);
        reloading = true;
    }
}
