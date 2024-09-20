using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueSpikeSlimeAI : MonoBehaviour
{
    //bool _isDead;
    bool IsfacingRight = true;
    Rigidbody2D SpikyBod;
    public Animator SpikyAnim;
    public Collider2D SpikeSensor;
    float Speed = 1.7f;
    GameObject player;
    public Collider2D TreeBod;
    bool treetrue = false;
    float treeTime = 1f;
    void Start()
    {
        //_isDead = false;
        IsfacingRight = true;
        SpikyBod = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(IsfacingRight == true)
        {
            SpikyBod.velocity = new Vector2(Speed, 0f);
            SpikyAnim.SetBool("_isRight", true);
        }
        if(IsfacingRight == false)
        {
            SpikyBod.velocity = new Vector2(-Speed, 0f);
            SpikyAnim.SetBool("_isRight", false);
        }
    }
    void FixedUpdate()
    {
        if(treetrue == true)
        {
            //RigidTree.constraints = RigidbodyConstraints2D.FreezeAll;
            treeTime -= Time.fixedDeltaTime;
            if(treeTime <= 0f)
            {
                treeTime = 1f;
                //if(IsfacingRight == true)
                //{
                //SpikyBod.velocity = new Vector2(Speed, 0f);
                //SpikyAnim.SetBool("_isRight", true);
                //}
                //if(IsfacingRight == false)
                //{
                //    SpikyBod.velocity = new Vector2(-Speed, 0f);
                //    SpikyAnim.SetBool("_isRight", false);
                //}
            }
        }
    }
    void OnTriggerExit2D(Collider2D SpikeSensor)
    {
        GameObject attack = GameObject.FindGameObjectWithTag("attack");
        if (attack == null)
        {
            transform.Rotate(0f,180f,0f);
            IsfacingRight = !IsfacingRight;
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            TreeBod.enabled = true;
            treetrue = true;
        }
    }
    void OnTriggerEnter2D(Collider2D TreeBod)
    {
        impy_move enemy = TreeBod.GetComponent<impy_move>();
        if(enemy != null)
        {
            //SpikyBod.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Attack");
            enemy.takeDamage(40);
            SpikyAnim.SetTrigger("_attack");
        }
    }
}
