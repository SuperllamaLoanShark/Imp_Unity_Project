using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlant : MonoBehaviour
{
    int health = 1;
    Rigidbody2D plantBod;
    Collider2D plantC;
    public GameObject spawn;
    void Start()
    {
        plantBod = GetComponent<Rigidbody2D>();
        plantC = GetComponent<Collider2D>();
        plantBod.gravityScale = 0;
    }
    void Update()
    {
        
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
        plantBod.gravityScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D plantC)
    {
        swordScript attack1 = plantC.GetComponent<swordScript>();
        FireballScrpit attack2 = plantC.GetComponent<FireballScrpit>();
        CoraTipoli enemy = plantC.GetComponent<CoraTipoli>();
        spawn.GetComponent<fallingPlantSpawn>().respawn();
        if(enemy != null)
        {
            Debug.Log("Hit!");
            enemy.BushHit();
            Destroy(gameObject);
        }
        if(attack1 == null && attack2 == null && spawn == null)
        {
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
