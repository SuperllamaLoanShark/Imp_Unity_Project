using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiky_AI : MonoBehaviour
{
    public int health = 100;
    //public GameObject _deathEffect;
    [SerializeField] float Speed = 1.7f;
    Rigidbody2D SpikyBod; 
    public Collider2D headSpike;
    public Collider2D facesensor;
    public GameObject _slimeItself;
    GameObject player;
    public Animator SlimyAnim;
    float chaseRadius = 5f;
    float RunSpeed = 5f;
    public bool IsfacingRight;
    bool _isDead;
    float _deadTime = 2.3f;
    
    void Start()
    {
        _isDead = false;
        IsfacingRight = true;
        SpikyBod = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(IsfacingRight == true)
        {
            SpikyBod.velocity = new Vector2(Speed, 0f);
            SlimyAnim.SetBool("_isRight", true);
        }
        if(IsfacingRight == false)
        {
            SpikyBod.velocity = new Vector2(-Speed, 0f);
            SlimyAnim.SetBool("_isRight", false);
        }
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= chaseRadius)
        {
            SlimyAnim.SetBool("_isRunning", true);
            Speed = RunSpeed;
        }
        if (distance > chaseRadius)
        {
            SlimyAnim.SetBool("_isRunning", false);
            Speed = 1.7f;
        }
    }
    void OnTriggerExit2D(Collider2D facesensor)
    {
        GameObject attack = GameObject.FindGameObjectWithTag("attack");
        if (attack == null)
        {
            transform.Rotate(0f,180f,0f);
            IsfacingRight = !IsfacingRight;
        }
    }
    private void OnTriggerEnter2D(Collider2D headSpike)
    {
        impy_move enemy = headSpike.GetComponent<impy_move>();
        if(enemy != null)
        {
            enemy.takeDamage(40);
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
    void FixedUpdate()
    {
        if(_isDead == true)
        {
            _deadTime -= Time.fixedDeltaTime;
            if (_deadTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void Die()
    {
        facesensor.enabled = false;
        headSpike.enabled = false;
        SlimyAnim.SetTrigger("_isDead");
        _isDead = true;
        SpikyBod.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}