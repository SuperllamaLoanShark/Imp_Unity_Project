using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScrpit : MonoBehaviour
{
    public float _speed = 20f;
    public Rigidbody2D FireBod;

    void Start()
    {
        FireBod.velocity = transform.right * _speed;
        transform.Rotate(0f, 0f, -90f);
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        spiky_AI enemy = hitinfo.GetComponent<spiky_AI>();
        if(enemy != null)
        {
            enemy.takeDamage(40);
        }
        JumpingBeanAI enemy2 = hitinfo.GetComponent<JumpingBeanAI>();
        if(enemy2 != null)
        {
            enemy2.takeDamage(40);
        }
        _lichen_Lu enemy3 = hitinfo.GetComponent<_lichen_Lu>();
        if(enemy3 != null)
        {
            enemy3.takeDamage(40);
        }
        //shieldScript enemy4 = hitinfo.GetComponent<shieldScript>();
        //if (enemy4 != null)
        //{
        //    enemy4.takeDamage(1);
        //}
        fallingPlant enemy4 = hitinfo.GetComponent<fallingPlant>();
        if (enemy4 != null)
        {
            enemy4.takeDamage(1);
        }
        CoraTipoli enemy5 = hitinfo.GetComponent<CoraTipoli>();
        if(enemy5 != null)
        {
            enemy5.takeDamage(20);
        }
        Destroy(gameObject);
    }
}
