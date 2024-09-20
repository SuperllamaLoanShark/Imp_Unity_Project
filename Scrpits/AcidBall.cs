using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBall : MonoBehaviour
{
    float speed = 7f;
    //public Transform TPlayer;
    GameObject target;
    Rigidbody2D AcidBod;
    //public Transform ACID;
    void Start()
    {
        AcidBod = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        AcidBod.velocity = new Vector2(moveDir.x, moveDir.y);
        //AcidBod.velocity =  (TPlayer.position - transform.position).normalized * speed;
        //transform.Rotate(0f, 0f, -90f);
    }
    private void OnTriggerEnter2D(Collider2D AcidBod)
    {
        impy_move enemy = AcidBod.GetComponent<impy_move>();
        if(enemy != null)
        {
            Debug.Log("Hit!");
            enemy.takeDamage(40);
        }
        Destroy(gameObject);
    }
}
