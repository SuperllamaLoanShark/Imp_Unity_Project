using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public Collider2D shield;
    public int health = 1;
    bool destroyed;
    float timer = 10f;
    float secondtimer = .8f;
    public Animator shieldAnim;
    void Start()
    {
        destroyed = true;
    }
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("attackPos");
        transform.position = target.transform.position;
        transform.rotation = target.transform.rotation;
    }
    void FixedUpdate()
    {
        if(destroyed == true)
        {
            timer -= Time.fixedDeltaTime;
            if(timer <= 0f)
            {
                Die();
                secondtimer -= Time.fixedDeltaTime;
                if(secondtimer <= 0f)
                {
                    Destroy(gameObject);
                }
            }
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
        shieldAnim.SetTrigger("destroyed");
        destroyed = true;
        shield.enabled = false;
    }
}