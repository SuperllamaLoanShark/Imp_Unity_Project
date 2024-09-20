using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoraBabyScript : MonoBehaviour
{
    public Rigidbody2D _beanyBod;
    private float _jumpyTime = 12f;
    public Collider2D _beanyHead;
    public Animator _JumpyAnim;
    private float _xSpeed = 8f;
    private bool IsfacingRight = true;
    public int health = 100;
    public Collider2D _beanyBody;
    float DeathAnim;
    private bool _dead = false;
    //public GameObject Cora_Tipoli;

    void Start()
    {
        //Boss = GameObject.FindGameObjectWithTag("Boss");
        //Cora_Tipoli = GameObject.FindGameObjectWithTag("Boss");
        //CoraTipoli Cora = GetComponent<CoraTipoli>;
        DeathAnim = 1.6f;
        _beanyBod.velocity = new Vector2(10f,10f);
    }
    void Update()
    {
        if(IsfacingRight == true)
        {
            _JumpyAnim.SetBool("_isRight", true);
        }
        else
        {
            _JumpyAnim.SetBool("_isRight", false);
        }
        _jumpyTime -= Time.fixedDeltaTime;
        if(_jumpyTime<= 0f)
        {
            _beanyBod.velocity = new Vector2(_xSpeed,8f);
            _jumpyTime = 12f;
        }
        if(IsfacingRight == true)
        {
            _xSpeed = 8f;
        }
        else
        {
            _xSpeed = -8f;
        }
    }
    void FixedUpdate()
    {
        if(_dead == true)
        {
            DeathAnim -= Time.fixedDeltaTime;
            if( DeathAnim<=0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject attack = GameObject.FindGameObjectWithTag("attack");
        if (attack == null)
        {
            transform.Rotate(0f,180f,0f);
            IsfacingRight = !IsfacingRight;
        }
    }
    private void OnTriggerEnter2D(Collider2D _beanyBody)
    {
        impy_move enemy = _beanyBody.GetComponent<impy_move>();
        if(enemy != null)
        {
            Debug.Log("Hit!");
            enemy.takeDamage(30);
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
        //Cora_Tipoli.GetComponent<CoraTipoli>;
        //Cora_Tipoli._lessEnemy();
        _beanyBod.constraints = RigidbodyConstraints2D.FreezeAll;
        _beanyBod.isKinematic = true;
        _JumpyAnim.SetTrigger("_dead");
        _dead = true;
    }
}
