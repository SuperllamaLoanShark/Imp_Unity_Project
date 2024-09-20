using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _lichen_Lu : MonoBehaviour
{
    public int health = 40;
    public Collider2D lu_s_bod;
    //public bool _active = false;
    bool _isRight = true;
    public Animator Lulu;
    public Transform Acid;
    public GameObject Acidball;
    bool hasAttacked = false;
    float AcidTime = 3f;
    GameObject player;
    void FixedUpdate()
    {
        if(hasAttacked)
        {
            AcidTime -= Time.fixedDeltaTime;
        }
        if(AcidTime <= 0f)
        {
            AcidTime = 3f;
            hasAttacked = false;
        }
    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance < 30f)
        {
            Attack();
        }
        if (player.transform.position.x > transform.position.x && _isRight == false)
        {
            _isRight = true;
            transform.Rotate(0f,180f,0f);
            Lulu.SetBool("_isLeft", false);
        }
        if (player.transform.position.x < transform.position.x && _isRight == true)
        {
            _isRight = false;
            transform.Rotate(0f,180f,0f);
            Lulu.SetBool("_isLeft", true);
        }
    }
    public void takeDamage( int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Attack()
    {
        if(AcidTime >= 3f)
        {
            Instantiate(Acidball, Acid.position, Acid.rotation);
            AcidTime -= Time.fixedDeltaTime;
            hasAttacked = true;
        }
    }
}
